using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_MirrorStateOfSFSMWithBuildedCSharp : MonoBehaviour
{

    public StringFSMDeductedScriptable m_fsmPatternObserved;
    public Transform m_direction;
    public Rigidbody m_body;

    public Vector3 m_upForce = Vector3.up;
    public float m_jumpForce = 10;
    public float m_doubleJumpforce = 2;
    public float m_walkForce = 2;
    public float m_runForce = 5;



    [Header("For Debug view purpose State")]
    public byte m_previousState;
    public byte m_currentState;
    public byte m_transactionIdReceived;
    public byte m_transactionIdPrevious;
    [Header("For Debug view purpose CONST")]
    public byte m_stateIdle =SFSM.PLAYERMOVE.S_IDLE;
    public byte m_stateWalk = SFSM.PLAYERMOVE.S_WALK;
    public byte m_stateRun = SFSM.PLAYERMOVE.S_RUN;
    public byte m_stateJump = SFSM.PLAYERMOVE.S_JUMP;
    public byte m_stateDoubleJump = SFSM.PLAYERMOVE.S_DOUBLEJUMP;
    public byte m_stateFalling = SFSM.PLAYERMOVE.S_FALLING;


    public ByteIdQueue m_transitionReceived = new ByteIdQueue();
    private StringFSMAccess access;
    public void Awake()
    {
        access = new StringFSMAccess(m_fsmPatternObserved);
    }
    [ContextMenu("Go Next Random Transaction")]
    public void ForceToMoveToRandomNextTransaction() {
        if(access==null)
            access = new StringFSMAccess(m_fsmPatternObserved);
        access.GetRandomNextTransactionIdFromTransaction(in m_transactionIdReceived, out byte nextId);
        NotifyNewTransactionWasValidated( nextId);
    }

    public void NotifyNewTransactionWasValidated( byte transactionId)
    {
        m_transactionIdPrevious = m_transactionIdReceived;
        m_transactionIdReceived = transactionId;
        access.GetStatesOfTransactionId(in transactionId, out m_previousState, out m_currentState);
        m_transitionReceived.Enqueue(transactionId);
    }

    public void NotifyNewTransactionWasValidated(byte sourceState, byte destinationState, byte transactionId) {
        m_previousState = sourceState;
        m_currentState = destinationState;
        m_transactionIdReceived = transactionId;
        m_transitionReceived.Enqueue(transactionId);

    }

    void Update()
    {
        while (m_transitionReceived.Count > 0) {
            byte tId = m_transitionReceived.Dequeue();
            if (tId == SFSM.PLAYERMOVE.T_JUMP_JUMP_DOUBLEJUMP)
            {
                m_body.AddForce(Vector3.up * m_doubleJumpforce, ForceMode.Impulse);
            }
            else if (tId == SFSM.PLAYERMOVE.T_JUMP_IDLE_JUMP
                || tId == SFSM.PLAYERMOVE.T_JUMP_RUN_JUMP
                || tId == SFSM.PLAYERMOVE.T_JUMP_WALK_JUMP) {

                m_body.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            }
        }
        
        if (m_currentState == m_stateWalk) { 
            m_body.AddForce(Vector3.forward * m_walkForce * Time.deltaTime, ForceMode.Acceleration);
        }
        if (m_currentState == m_stateRun) { 
            m_body.AddForce(Vector3.forward * m_runForce * Time.deltaTime, ForceMode.Acceleration);
        }
    }
}
