﻿using UnityEngine;
using System; // for event handler
using System.Collections;

public enum CommandType{
	ATTACK,
	DEFEND,
	SENTRY
}

public class CommandEventArgs : EventArgs{
	public Command command;
}

public class Command{
	public CommandType commandType;
	public Vector3 location;
	public Bug source;
	public Bug target;
}
