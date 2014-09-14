using UnityEngine;
using System; // for event handler
using System.Collections;


public class Player : MonoBehaviour {  // CRINGE!  Don't really need it to be a monobehavior, but easier than passing PF from GameController
	
	private Command[] commands;

	public Player(){
		commands = new Command[AppSettings.NUMBER_OF_BUGS];
	}

	public void StartInit(){
	}

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

	protected virtual void Start () {
		Debug.Log("Player Start()");
	}

}

