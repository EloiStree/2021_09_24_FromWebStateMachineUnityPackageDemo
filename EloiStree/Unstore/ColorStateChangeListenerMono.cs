using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorStateChangeListenerMono : MonoBehaviour, IFSMStateIndexChangeListener
{
    [Tooltip("Must be of emitter Inteface")]
    public GameObject m_stateChangeEmitter;
    public IFSMIndexStateChangeEmitter m_stateEmitter;
    public Eloi.StateChange m_stateChange;
    public Image m_imgageToAffect;
    public S_RGBSTATEMACHINE m_color;

    void Start()
    {
        if (m_stateChangeEmitter != null)
        {
            m_stateEmitter = m_stateChangeEmitter.GetComponent<IFSMIndexStateChangeEmitter>();
            if (m_stateEmitter != null)
                m_stateEmitter.AddStateIndexChangeListener(this);
        }
    }
    private void OnDestroy()
    {
        if (m_stateEmitter != null)
            m_stateEmitter.RemoveStateIndexChangeListener(this);
    }

  
    private void OnValidate()
    {
        if (m_stateChangeEmitter != null) { 
            m_stateEmitter = m_stateChangeEmitter.GetComponent<IFSMIndexStateChangeEmitter>();
            if (m_stateEmitter == null)
                m_stateChangeEmitter = null;
        }
       
    }

    public void OnStateIndexChange( byte fromStateIndex,  byte toStateIndex)
    {
        m_stateChange.SetWith(in fromStateIndex, in toStateIndex);
        m_color =(S_RGBSTATEMACHINE) (toStateIndex);
        switch (m_color)
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
            default:
                break;
        }
    }
}
