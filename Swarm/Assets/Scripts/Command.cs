using UnityEngine;
using System.Collections;

public enum CommandType{
	ATTACK,
	DEFEND,
	SENTRY
}

public class Command{
	public CommandType commandType;
	public Vector3 location;
//	public Bug target; // may change Bug to something more specific, after we have determined valid targets.
}
