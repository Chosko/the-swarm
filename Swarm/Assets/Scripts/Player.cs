using UnityEngine;
using System; // for event handler
using System.Collections;


public class Player : MonoBehaviour {  // CRINGE!  Don't really need it to be a monobehavior, but easier than passing PF from GameController
	
	public const int NUMBER_OF_PLAYERS = 2;
	public const int NUMBER_OF_BUGS = 5;

	public GameObject bugPf;

	private Command[] commands;
	private Player[] players;

	private GameObject[] bugPool;
	private Bug[] bugs;

	public Player(){
		commands = new Command[NUMBER_OF_BUGS];
		players = new Player[NUMBER_OF_PLAYERS];
	}

	public void StartInit(){
		bugPool = new GameObject[NUMBER_OF_BUGS];
		bugs = new Bug[NUMBER_OF_BUGS];

		//  Object instantiate these fellas.
		Vector3 _position = new Vector3(0f,0f,0f); // whatev... change this for a better layout
		for (int i=0; i < NUMBER_OF_BUGS; i++){
			_position.x = 2*i-1.5f;
			bugPool[i] = UnityEngine.GameObject.Instantiate(bugPf, _position, Quaternion.Euler(new Vector3()) ) as GameObject;
			bugs[i] = bugPool[i].GetComponent<Bug>();
//			spheres[i].Init(i, _position,sphereColors[i]);
//			spheres[i].SphereSelectionEvent += OnSphereClicked;
		}

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

}

