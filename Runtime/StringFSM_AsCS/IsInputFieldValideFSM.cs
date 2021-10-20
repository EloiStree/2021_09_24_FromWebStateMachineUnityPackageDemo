
public enum S_ISINPUTFIELDVALIDE : byte { NOTDEFINED = 0, NEWVALUE = 1, FIELDISEMPTY = 2, NOTALLOWEDCHARACTER = 3, NOTRESPECTINGREGEX = 4, TEXTISVALIDE = 5 }
public enum T_ISINPUTFIELDVALIDE : byte { NEXT_NOTDEFINED_NEWVALUE = 0, NEXT_NEWVALUE_FIELDISEMPTY = 1, NEXT_FIELDISEMPTY_NOTALLOWEDCHARACTER = 2, NEXT_NOTALLOWEDCHARACTER_NOTRESPECTINGREGEX = 3, NEXT_NOTRESPECTINGREGEX_TEXTISVALIDE = 4 }

//--------------------



public interface SFSM_IISINPUTFIELDVALIDE
{
	void ForceChangeToNOTDEFINED();
	void ForceChangeToNEWVALUE();
	void ForceChangeToFIELDISEMPTY();
	void ForceChangeToNOTALLOWEDCHARACTER();
	void ForceChangeToNOTRESPECTINGREGEX();
	void ForceChangeToTEXTISVALIDE();
	void TryTransitionThrowNEXT();
}


//--------------------

//*

public partial class SFSM
{
	public const byte S_ISINPUTFIELDVALIDE_NOTDEFINED = 0;
	public const byte S_ISINPUTFIELDVALIDE_NEWVALUE = 1;
	public const byte S_ISINPUTFIELDVALIDE_FIELDISEMPTY = 2;
	public const byte S_ISINPUTFIELDVALIDE_NOTALLOWEDCHARACTER = 3;
	public const byte S_ISINPUTFIELDVALIDE_NOTRESPECTINGREGEX = 4;
	public const byte S_ISINPUTFIELDVALIDE_TEXTISVALIDE = 5;
	public const byte T_ISINPUTFIELDVALIDE_NEXT_NOTDEFINED_NEWVALUE = 0;
	public const byte T_ISINPUTFIELDVALIDE_NEXT_NEWVALUE_FIELDISEMPTY = 1;
	public const byte T_ISINPUTFIELDVALIDE_NEXT_FIELDISEMPTY_NOTALLOWEDCHARACTER = 2;
	public const byte T_ISINPUTFIELDVALIDE_NEXT_NOTALLOWEDCHARACTER_NOTRESPECTINGREGEX = 3;
	public const byte T_ISINPUTFIELDVALIDE_NEXT_NOTRESPECTINGREGEX_TEXTISVALIDE = 4;
}
//*/

//*

public partial class SFSM
{

	public static class ISINPUTFIELDVALIDE
	{
		public const byte S_NOTDEFINED = 0;
		public const byte S_NEWVALUE = 1;
		public const byte S_FIELDISEMPTY = 2;
		public const byte S_NOTALLOWEDCHARACTER = 3;
		public const byte S_NOTRESPECTINGREGEX = 4;
		public const byte S_TEXTISVALIDE = 5;
		public const byte T_NEXT_NOTDEFINED_NEWVALUE = 0;
		public const byte T_NEXT_NEWVALUE_FIELDISEMPTY = 1;
		public const byte T_NEXT_FIELDISEMPTY_NOTALLOWEDCHARACTER = 2;
		public const byte T_NEXT_NOTALLOWEDCHARACTER_NOTRESPECTINGREGEX = 3;
		public const byte T_NEXT_NOTRESPECTINGREGEX_TEXTISVALIDE = 4;
	}
}
//*/

//--------------------



public class SFSM_ISINPUTFIELDVALIDE : SFSM_IISINPUTFIELDVALIDE
{
	public void ForceChangeToNOTDEFINED()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToNEWVALUE()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToFIELDISEMPTY()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToNOTALLOWEDCHARACTER()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToNOTRESPECTINGREGEX()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToTEXTISVALIDE()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowNEXT()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}


}
