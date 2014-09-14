using UnityEngine;
using System; // for event handler
using System.Collections;

public enum CommandType{
	ATTACK,
	DEFEND,
	SENTRY
}

public class CommandEventArgs : EventArgs{
	public Command command;
	public int bugId; //source bug
}

public class Command{
	public CommandType commandType;
	public Vector3 location;
	public Bug source;
	public Bug target;
//	public Bug target; // may change Bug to something more specific, after we have determined valid targets.
}
