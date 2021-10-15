using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorStateChangeListenerFromEnumMono : MonoBehaviour, IStateChangeFullReceiver, IStateChangeByteWithFineStateReceiver
{

    public Image m_imgageToAffect;
    [Header("Debug")]
    public S_RGBSTATEMACHINE m_colorCurrent;
    public S_RGBSTATEMACHINE m_colorPrevious;
    public StringFSMDeductedScriptable m_source;
    public bool m_stateReceived;


    public void OnStateIndexChange(S_RGBSTATEMACHINE newState)
    {
        switch (newState)
        {
            case S_RGBSTATEMACHINE.RED:
                m_imgageToAffect.color = Color.red;
                break;
            case S_RGBSTATEMACHINE.GREEN:
                m_imgageToAffect.color = Color.green;
                break;
            case S_RGBSTATEMACHINE.BLUE:
                m_imgageToAffect.color = Color.blue;
                break;
            case S_RGBSTATEMACHINE.WHITE:
                m_imgageToAffect.color = Color.white;
                break;
            case S_RGBSTATEMACHINE.BLACK:
                m_imgageToAffect.color = Color.black;
                break;
            case S_RGBSTATEMACHINE.BLUATRE:
                m_imgageToAffect.color = new Color(41f / 255f, 132f / 255f, 134f /255f);
                break;
                
            default:
                break;
        }
    }

    public void NotifyStateChange(byte fromState, byte toState)
    {
        m_colorCurrent = (S_RGBSTATEMACHINE)toState;
        m_colorPrevious = (S_RGBSTATEMACHINE)fromState;
        OnStateIndexChange(m_colorCurrent);
        m_stateReceived = true;
    }

    public void NotifyStateChange(StateChange stateChange)
    {
        NotifyStateChange(stateChange.m_fromStateIndex, stateChange.m_toStateIndex);
        m_stateReceived = true;
    }

    public void NotifyStateChangeFineState(StateChangeWithFineState stateChange)
    {
        NotifyStateChange(stateChange.m_fromStateIndex, stateChange.m_toStateIndex);
        m_stateReceived = true;
    }
    public void NotifyStateChangeWithSource(IContainSFSMDeductedInfo source, S_RGBSTATEMACHINE from, S_RGBSTATEMACHINE to)
    {
        m_colorPrevious = from;
        m_colorCurrent = to;
        OnStateIndexChange(to);
        source.GetFSMDeducted(out m_source);
        m_stateReceived = true;
    }
    public void NotifyStateChangeWithSource( S_RGBSTATEMACHINE from, S_RGBSTATEMACHINE to)
    {
        m_colorPrevious = from;
        m_colorCurrent = to;
        OnStateIndexChange(to);
        m_stateReceived = true;
    }

    public void NotifyStateChange(string fromState, string toState)
    {
        throw new System.NotImplementedException();
    }

    public void NotifyStateChange(IContainSFSMDeductedInfo source, byte fromState, byte toState)
    {
        ByteStateChangeToEnumUtility<S_RGBSTATEMACHINE>.StaticGetEnumFromSafe(in fromState, in toState,
            out m_colorPrevious, out m_colorCurrent, out bool converted);
        
        if (converted)
            OnStateIndexChange(m_colorCurrent);
        if(source!=null)
            source.GetFSMDeducted(out m_source);
    }
}
