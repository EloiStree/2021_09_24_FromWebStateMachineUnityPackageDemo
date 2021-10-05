using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SFSM_CheckTextValidity : MonoBehaviour
{

    public StringFSMDeductedScriptable m_fsmPatternObserved;
    private StringFSMAccess m_access;
    public string m_description = "Must be a number";
    public string m_notAllowedChar = ",</>!";
    public string m_regexToFit = "[+-]?([0-9]*[.])?[0-9]+";

   

    public void Awake()
    {
        m_access = new StringFSMAccess(m_fsmPatternObserved);
    }

  

        public void IsTextValide(string text
        , out bool isValide,
        out S_ISINPUTFIELDVALIDE reasonWhyNotValide)
    {
        byte stateId;
        m_access.GetInitStateId(out stateId);
        int antiLoop = 0;
        while (CanGoNext(in text, stateId, out stateId))
        {

            antiLoop++;
            if (antiLoop > 100)
            {
                Debug.Log("Loop here");
                break;
            }
        }

        isValide = false;
        reasonWhyNotValide = (S_ISINPUTFIELDVALIDE) stateId;


    }

    private bool CanGoNext(in string text, byte currentstateId, out byte nextstateId)
    {
        bool foundNextId = false ;
        nextstateId = currentstateId;
        string nextTransition = "Next";
        bool conditionValideForNext = false;
        S_ISINPUTFIELDVALIDE valideState = (S_ISINPUTFIELDVALIDE)currentstateId;
        switch (valideState)
        {
            case S_ISINPUTFIELDVALIDE.NOTDEFINED:
                conditionValideForNext = text != null && text.Length > 0;
                break;
            case S_ISINPUTFIELDVALIDE.NEWVALUE:
                conditionValideForNext = text != null && text.Length > 0;
                break;
            case S_ISINPUTFIELDVALIDE.FIELDISEMPTY:
                conditionValideForNext = !string.IsNullOrWhiteSpace(text) ;
                break;
            case S_ISINPUTFIELDVALIDE.NOTALLOWEDCHARACTER:
                conditionValideForNext = !IsContainingNotAlloWChar(in text, in m_notAllowedChar);
                break;
            case S_ISINPUTFIELDVALIDE.NOTRESPECTINGREGEX:
                conditionValideForNext = IsTextRespectRegex(in text, in m_regexToFit);
                break;
            case S_ISINPUTFIELDVALIDE.TEXTISVALIDE:
                break;
            default:
                break;
        }
        if(conditionValideForNext==true)
           CheckIfCanContinueNext(currentstateId, ref nextstateId, ref foundNextId, in nextTransition);
            

        return foundNextId;
    }

    private bool IsTextRespectRegex(in string text, in string regex)
    {
        Regex r = new Regex(regex);
        if (r.IsMatch(text))
        {
            return true;
        }
        return false;
    }

    private bool IsContainingNotAlloWChar(in string text, in string charaterAuthorized)
    {
        for (int i = 0; i < charaterAuthorized.Length; i++)
        {
            char c = charaterAuthorized[i];
            for (int j = 0; j < text.Length; j++)
            {
                if (text[j] == c)
                    return true;
            }
        }
        return false;
    }

    private void CheckIfCanContinueNext(byte currentstateId, ref byte nextstateId, ref bool foundNextId, in string nextTransition)
    {
        m_access.HasNextStateForTransition(in currentstateId, in nextTransition, out bool found, out byte nextIdStateFound);
        if (found)
        {
            nextstateId = nextIdStateFound;
            foundNextId = true;
        }
    }
}
