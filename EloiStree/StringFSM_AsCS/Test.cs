
public enum S_PLAYERMOVE : byte { IDLE = 0, WALK = 1, RUN = 2, JUMP = 3, DOUBLEJUMP = 4, FALLING = 5 }
public enum T_PLAYERMOVE : byte { WALKING_IDLE_WALK = 0, WALKING_RUN_WALK = 1, RUNNING_IDLE_RUN = 2, RUNNING_WALK_RUN = 3, JUMP_IDLE_JUMP = 4, JUMP_WALK_JUMP = 5, JUMP_RUN_JUMP = 6, JUMP_JUMP_DOUBLEJUMP = 7, FALLING_JUMP_FALLING = 8, FALLING_DOUBLEJUMP_FALLING = 9, STOP_WALK_IDLE = 10, STOP_RUN_IDLE = 11, AIRSTOP_JUMP_IDLE = 12, AIRSTOP_DOUBLEJUMP_IDLE = 13, AIRSTOP_FALLING_IDLE = 14 }

//--------------------



public interface SFSM_IPLAYERMOVE
{
	void ForceChangeToIDLE();
	void ForceChangeToWALK();
	void ForceChangeToRUN();
	void ForceChangeToJUMP();
	void ForceChangeToDOUBLEJUMP();
	void ForceChangeToFALLING();


	void TryTransitionThrowWALKING();
	void TryTransitionThrowRUNNING();
	void TryTransitionThrowJUMP();
	void TryTransitionThrowFALLING();
	void TryTransitionThrowSTOP();
	void TryTransitionThrowAIRSTOP();


}


//--------------------

/*

public partial class SFSM
{
	public const byte S_PLAYERMOVE_IDLE = 0;
	public const byte S_PLAYERMOVE_WALK = 1;
	public const byte S_PLAYERMOVE_RUN = 2;
	public const byte S_PLAYERMOVE_JUMP = 3;
	public const byte S_PLAYERMOVE_DOUBLEJUMP = 4;
	public const byte S_PLAYERMOVE_FALLING = 5;
	public const byte T_PLAYERMOVE_WALKING_IDLE_WALK = 0;
	public const byte T_PLAYERMOVE_WALKING_RUN_WALK = 1;
	public const byte T_PLAYERMOVE_RUNNING_IDLE_RUN = 2;
	public const byte T_PLAYERMOVE_RUNNING_WALK_RUN = 3;
	public const byte T_PLAYERMOVE_JUMP_IDLE_JUMP = 4;
	public const byte T_PLAYERMOVE_JUMP_WALK_JUMP = 5;
	public const byte T_PLAYERMOVE_JUMP_RUN_JUMP = 6;
	public const byte T_PLAYERMOVE_JUMP_JUMP_DOUBLEJUMP = 7;
	public const byte T_PLAYERMOVE_FALLING_JUMP_FALLING = 8;
	public const byte T_PLAYERMOVE_FALLING_DOUBLEJUMP_FALLING = 9;
	public const byte T_PLAYERMOVE_STOP_WALK_IDLE = 10;
	public const byte T_PLAYERMOVE_STOP_RUN_IDLE = 11;
	public const byte T_PLAYERMOVE_AIRSTOP_JUMP_IDLE = 12;
	public const byte T_PLAYERMOVE_AIRSTOP_DOUBLEJUMP_IDLE = 13;
	public const byte T_PLAYERMOVE_AIRSTOP_FALLING_IDLE = 14;
}
//*/

//*

public partial class SFSM
{

	public static class PLAYERMOVE
	{
		public const byte S_IDLE = 0;
		public const byte S_WALK = 1;
		public const byte S_RUN = 2;
		public const byte S_JUMP = 3;
		public const byte S_DOUBLEJUMP = 4;
		public const byte S_FALLING = 5;
		public const byte T_WALKING_IDLE_WALK = 0;
		public const byte T_WALKING_RUN_WALK = 1;
		public const byte T_RUNNING_IDLE_RUN = 2;
		public const byte T_RUNNING_WALK_RUN = 3;
		public const byte T_JUMP_IDLE_JUMP = 4;
		public const byte T_JUMP_WALK_JUMP = 5;
		public const byte T_JUMP_RUN_JUMP = 6;
		public const byte T_JUMP_JUMP_DOUBLEJUMP = 7;
		public const byte T_FALLING_JUMP_FALLING = 8;
		public const byte T_FALLING_DOUBLEJUMP_FALLING = 9;
		public const byte T_STOP_WALK_IDLE = 10;
		public const byte T_STOP_RUN_IDLE = 11;
		public const byte T_AIRSTOP_JUMP_IDLE = 12;
		public const byte T_AIRSTOP_DOUBLEJUMP_IDLE = 13;
		public const byte T_AIRSTOP_FALLING_IDLE = 14;
	}
}
//*/

//--------------------



public class SFSM_PLAYERMOVE : SFSM_IPLAYERMOVE
{
	public void ForceChangeToIDLE()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToWALK()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToRUN()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToJUMP()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToDOUBLEJUMP()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void ForceChangeToFALLING()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowWALKING()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowRUNNING()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowJUMP()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowFALLING()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowSTOP()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}
	public void TryTransitionThrowAIRSTOP()
	{
		//Add Your code here
		throw new System.NotImplementedException();
	}


}
