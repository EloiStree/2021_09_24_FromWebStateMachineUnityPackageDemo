
public enum S_RGBSTATEMACHINE : byte { RED = 0, GREEN = 1, BLUE = 2, WHITE = 3, BLACK = 4 }
public enum T_RGBSTATEMACHINE : byte { SETRED_GREEN_RED = 0, SETRED_RED_RED = 1, SETGREEN_BLUE_GREEN = 2, SETGREEN_RED_GREEN = 3, SETBLUE_RED_BLUE = 4, SETBLUE_GREEN_BLUE = 5, SETBLUE_BLACK_BLUE = 6, SETGREEN_BLACK_GREEN = 7, SETRED_BLACK_RED = 8, SETBLACK_WHITE_BLACK = 9 }

//--------------------



public interface SFSM_IRGBSTATEMACHINE
{
	void ForceChangeToRED();
	void ForceChangeToGREEN();
	void ForceChangeToBLUE();
	void ForceChangeToWHITE();
	void ForceChangeToBLACK();


	void TryTransitionThrowSETRED();
	void TryTransitionThrowSETGREEN();
	void TryTransitionThrowSETBLUE();
	void TryTransitionThrowSETBLACK();


}


//--------------------

//*

public partial class SFSM
{
	public const byte S_RGBSTATEMACHINE_RED = 0;
	public const byte S_RGBSTATEMACHINE_GREEN = 1;
	public const byte S_RGBSTATEMACHINE_BLUE = 2;
	public const byte S_RGBSTATEMACHINE_WHITE = 3;
	public const byte S_RGBSTATEMACHINE_BLACK = 4;
	public const byte T_RGBSTATEMACHINE_SETRED_GREEN_RED = 0;
	public const byte T_RGBSTATEMACHINE_SETRED_RED_RED = 1;
	public const byte T_RGBSTATEMACHINE_SETGREEN_BLUE_GREEN = 2;
	public const byte T_RGBSTATEMACHINE_SETGREEN_RED_GREEN = 3;
	public const byte T_RGBSTATEMACHINE_SETBLUE_RED_BLUE = 4;
	public const byte T_RGBSTATEMACHINE_SETBLUE_GREEN_BLUE = 5;
	public const byte T_RGBSTATEMACHINE_SETBLUE_BLACK_BLUE = 6;
	public const byte T_RGBSTATEMACHINE_SETGREEN_BLACK_GREEN = 7;
	public const byte T_RGBSTATEMACHINE_SETRED_BLACK_RED = 8;
	public const byte T_RGBSTATEMACHINE_SETBLACK_WHITE_BLACK = 9;
}
//*/

//*

public partial class SFSM
{

	public static class RGBSTATEMACHINE
	{
		public const byte S_RED = 0;
		public const byte S_GREEN = 1;
		public const byte S_BLUE = 2;
		public const byte S_WHITE = 3;
		public const byte S_BLACK = 4;
		public const byte T_SETRED_GREEN_RED = 0;
		public const byte T_SETRED_RED_RED = 1;
		public const byte T_SETGREEN_BLUE_GREEN = 2;
		public const byte T_SETGREEN_RED_GREEN = 3;
		public const byte T_SETBLUE_RED_BLUE = 4;
		public const byte T_SETBLUE_GREEN_BLUE = 5;
		public const byte T_SETBLUE_BLACK_BLUE = 6;
		public const byte T_SETGREEN_BLACK_GREEN = 7;
		public const byte T_SETRED_BLACK_RED = 8;
		public const byte T_SETBLACK_WHITE_BLACK = 9;
	}
}
//*/

//--------------------



public class SFSM_RGBSTATEMACHINE : SFSM_IRGBSTATEMACHINE
{
	public void ForceChangeToRED()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToGREEN()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToBLUE()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToWHITE()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToBLACK()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowSETRED()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowSETGREEN()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowSETBLUE()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowSETBLACK()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}


}
