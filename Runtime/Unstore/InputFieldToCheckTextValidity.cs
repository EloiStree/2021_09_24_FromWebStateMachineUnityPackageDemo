using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldToCheckTextValidity : MonoBehaviour
{
    public SFSM_CheckTextValidity m_textValidity;
    
    
    public bool m_isValide;
    public S_ISINPUTFIELDVALIDE m_stateStatue;

    public void IsTextValide(string text)
    {
        m_textValidity.IsTextValide(text, out m_isValide, out  m_stateStatue);
    }

}
