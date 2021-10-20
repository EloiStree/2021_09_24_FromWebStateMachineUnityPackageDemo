using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFSMObserver_StateEnter_Mono : SFSMObserverMono
{

    [Header("State Debug")]
    public StateEnterPassif m_listenToStateEntering;
    public byte m_previousState;
    [Header("Event")]
    public StateChangeFromToIndexEvent m_stateChangeBytes;

    [SerializeField] E_CodeTag.Inspector.WorkButNotProud m_warning = new E_CodeTag.Inspector.WorkButNotProud("This class has the problem of check every update the state of the machine. It works but can kill performance if too mush of them.");
    [SerializeField] E_CodeTag.Inspector.WorkButNotProud m_warning2 = new E_CodeTag.Inspector.WorkButNotProud("Observe a state byte don't provide the event of transition on the same state.");

    void Update()
    {
        GetByteState(out byte byteState);
        m_listenToStateEntering.GetCurrentState(out byte m_previousState);
        m_listenToStateEntering.SetObservedID(byteState);
        m_stateChangeBytes.Invoke(m_previousState, byteState);
    }
}

public class SFSMObserverMono : MonoBehaviour {

    public GameObject m_target;
    private IContaintStateAsByte m_byteState;
    private IContainSFSMDeductedInfo m_SFSM;

    public bool IsSourceTargetStringFineStateMachine() {
        return m_target.GetComponent<IContaintStateAsByte>() != null && m_target.GetComponent<IContainSFSMDeductedInfo>() != null ;
    }
    public void RemoveSourceIfNotSFSM() {
        if (!IsSourceTargetStringFineStateMachine()) { 
            m_target = null;
            m_byteState = null;
            m_SFSM = null;
        }
    }
    public void GetSFSM(out IContainSFSMDeductedInfo info)
    {
        CheckInterfaceExistance();
        info = m_SFSM;
    }
    public void GetSFSM(out StringFSMDeductedScriptable sfsm)
    {
        CheckInterfaceExistance();
        m_SFSM.GetFSMDeducted(out sfsm);
    }

    public void GetByteState(out byte byteState)
    {
        CheckInterfaceExistance();
        m_byteState.GetStateAsByte(out byteState);
    }

    public void GetByteState(out IContaintStateAsByte info)
    {
        CheckInterfaceExistance();
        info = m_byteState;
    }

    private void CheckInterfaceExistance()
    {
        if (m_target != null) {
            if (m_byteState == null)
            {
              m_byteState=  m_target.GetComponent<IContaintStateAsByte>();

                if (m_byteState == null)
                    throw new Exception("Your gameobject should has a state as byte but don't.");
            }
            if (m_SFSM == null)
            {
                m_SFSM = m_target.GetComponent<IContainSFSMDeductedInfo>();
                if (m_SFSM == null)
                    throw new Exception("Your gameobject should has a SFSM deduction but don't.");
            }
        }
    }

    private void OnValidate()
    {
        RemoveSourceIfNotSFSM();
    }
}
