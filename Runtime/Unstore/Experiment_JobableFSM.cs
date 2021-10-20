using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;
using Unity.Collections;
using System;
using System.Linq;

public class Experiment_JobableFSM : MonoBehaviour
{
    public StringFSMDeductedScriptable m_patternSouce;
    public StringFSMAccess m_access;

    public float m_minStateTime = 0.5f, m_maxStateTime = 3f, m_maxDoubleJump = 0.4f;
    public Example_PlayerMoveSensor [] m_sensors;
    public Example_MirrorStateOfSFSMWithBuildedCSharp[] m_bots;

    public int m_sensoreCount;
    public NativeArray<byte> m_lastTransitionsId;
    public NativeArray<byte> m_statesId;
    public NativeArray<float> m_stateTimeCount;
    public NativeArray<float> m_stateNextTimeCount;
    public string m_debugTransactions;
    public string m_debugStates;
    public string m_debugTimes;

    void Awake()
    {
        m_sensoreCount = m_sensors.Length;
        m_access = new StringFSMAccess(m_patternSouce);
        byte[] b = new byte[m_sensors.Length];
        float[] f = new float[m_sensors.Length];
        m_access.GetInitStateId(out byte initState);
        for (int i = 0; i < b.Length; i++)
        {
            b[i]=initState;
        }
        m_lastTransitionsId = new NativeArray<byte>(b, Allocator.Persistent);
        m_statesId = new NativeArray<byte>(b.ToArray(), Allocator.Persistent);
        m_stateTimeCount = new NativeArray<float>(f.ToArray(), Allocator.Persistent);
        m_stateNextTimeCount = new NativeArray<float>(f.ToArray(), Allocator.Persistent);



    }


    private void Update()
    {
        float delta = Time.deltaTime;
        for (int i = 0; i < m_sensoreCount; i++)
        {
            float timePast = m_stateTimeCount[i];
            byte state = m_statesId[i];
            if (state == SFSM.PLAYERMOVE.S_JUMP ||
                state == SFSM.PLAYERMOVE.S_DOUBLEJUMP
                )
            {
                if (timePast>0.1f && m_sensors[i].IsFalling_Velocity())
                {
                    PushNextStateTo(in i, SFSM.PLAYERMOVE.S_FALLING);
                }
                if (state== SFSM.PLAYERMOVE.S_JUMP && ( timePast > m_stateNextTimeCount[i] || timePast >m_maxDoubleJump)) {

                    SetWithStateFromState(in i, state, SFSM.PLAYERMOVE.S_DOUBLEJUMP);
                }
            }
            if (state == SFSM.PLAYERMOVE.S_FALLING)
            {
                if (timePast > 0.1f && m_sensors[i].HasGround_Raycast())
                {
                    PushNextStateTo(in i, SFSM.PLAYERMOVE.S_IDLE);
                }
            }

            if (!IsInState(state, SFSM.PLAYERMOVE.S_JUMP, SFSM.PLAYERMOVE.S_DOUBLEJUMP, SFSM.PLAYERMOVE.S_FALLING)) {

                if (timePast > m_stateNextTimeCount[i]) {
                    PushNextState(i);
                }
            }

            m_stateTimeCount[i] += delta;
        }

        m_debugTransactions = string.Join(" ", m_lastTransitionsId);
        m_debugStates = string.Join(" ", m_statesId);
        m_debugTimes = string.Join(" ", m_stateTimeCount);
    }

    private void PushNextState(in int index)
    {
        byte stateId = m_statesId[index];
        m_access.GetStateNextStatesIndex(in stateId, out IEnumerable<byte> states);
        byte newStateId = StringFSMAccess.RandomElement<byte>(states);
        SetWithStateFromState(in index, in stateId, in newStateId);
    }
    private void PushNextStateTo(in int index, byte nextStateId)
    {
        byte stateId = m_statesId[index];
        SetWithStateFromState(in index, in stateId, in nextStateId);
    }

    private void SetWithStateFromState(in int index, in byte previousStateId, in byte newStateId)
    {
        m_access.GetTransactionIdFromStatesId(in previousStateId,
            in newStateId,
            out byte transactionId);
        SetWith(in index, transactionId, newStateId);
    }

    public void SetWith(in int index, byte tranistionId, byte stateId)
    {
        m_statesId[index] = stateId;
        m_lastTransitionsId[index] = tranistionId;
        m_stateTimeCount[index] = 0;
        m_stateNextTimeCount[index] = UnityEngine.Random.Range(m_minStateTime, m_maxStateTime);
        m_bots[index].NotifyNewTransactionWasValidated(tranistionId);
    }

    public bool IsInState(byte id, params byte[] ids) {
        for (int i = 0; i < ids.Length; i++)
        {
            if (id == ids[i])
                return true;
        }
        return false;
    }
 

    private void OnDestroy()
    {
        if (m_lastTransitionsId.IsCreated)
            m_lastTransitionsId.Dispose();
        if (m_statesId.IsCreated)
            m_statesId.Dispose(); 
        if (m_stateNextTimeCount.IsCreated)
            m_stateNextTimeCount.Dispose();
        if (m_stateTimeCount.IsCreated)
            m_stateTimeCount.Dispose();
    }

}

//Use to convert throw BUffered or NativeArray;
public struct StringFSM_UintMinimalInformation {

    public StateAndTransactionIntegerRegister m_stateAndTransitions;
    public PerStateNeighborIndexCollectionAsIndex  m_perStateNeighbor;

}
// 
public struct StringFSM_NativeMinimalInformation
{
    public StateAndTransactionIntegerRegisterJobable m_stateAndTransitions;
    public NeighorNextJobable m_nextNeighbor;

    internal byte GetRandomNextState(byte v)
    {
        throw new NotImplementedException();
    }
}

public struct StringFSMIdStateCollection {

    public NativeArray<byte> m_SFSMstates;
}

public struct StringFSMIdState {
    public byte m_state;
}

//[BurstCompile(CompileSynchronously = true)]
public struct JobExeExperiment_GoNextState : IJobParallelFor
{
    public StringFSM_NativeMinimalInformation m_sfsmConnections;
    public NativeArray<byte> m_SFSMstates;

    public void Execute(int index)
    {
        m_SFSMstates[index] = m_sfsmConnections.GetRandomNextState(m_SFSMstates[index]);
    }
}