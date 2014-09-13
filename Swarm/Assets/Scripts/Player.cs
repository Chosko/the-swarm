using UnityEngine;
using System; // for event handler
using System.Collections;


public class CommandEventArgs : EventArgs{
	public Command command;
	public int bugId; //source bug
}


public class Player : MonoBehaviour {

	public delegate void CommandHandler(object sender, CommandEventArgs eventArgs);
	public event CommandHandler CommandEvent;
	//  sample code below for subscriber
	// 	player.CommandEvent += OnCommand;

	void FOO(){
		CommandEventArgs cea = new CommandEventArgs();
		Command fooCommand = new Command();
		cea.command = fooCommand;
		cea.bugId = 4; // some bug id
		CommandEvent(this, cea);
	}


}
