using UnityEngine;
using System; // for event handler
using System.Collections;


public class Player : MonoBehaviour {  // CRINGE!  Don't really need it to be a monobehavior, but easier than passing PF from GameController

	public Color color;
	private Command[] commands;

	private GameObject[] bugPoolP1;
	public Bug[] bugsP1;
	
	private GameObject[] bugPoolP2;
	public Bug[] bugsP2;

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
		bugPoolP1 = new GameObject[NUMBER_OF_BUGS];
		bugsP1 = new Bug[NUMBER_OF_BUGS];
		
		bugPoolP2 = new GameObject[NUMBER_OF_BUGS];
		bugsP2 = new Bug[NUMBER_OF_BUGS];
		
		//  Object instantiate these fellas.
		Vector3 _positionP1 = new Vector3(0f,0f,0f); // whatev... change this for a better layout
		Vector3 _positionP2 = new Vector3 (0f, 20f, 0f);
		for (int i=0; i < NUMBER_OF_BUGS; i++){
			_positionP1.x = 2*i-1.5f;
			bugPoolP1[i] = UnityEngine.GameObject.Instantiate(bugPf, _positionP1, Quaternion.Euler(new Vector3()) ) as GameObject;
			bugsP1[i] = bugPoolP1[i].GetComponent<Bug>();
			_positionP2.x = 2*i-1.5f;
			bugPoolP2[i] = UnityEngine.GameObject.Instantiate(bugPf, _positionP2, Quaternion.Euler(new Vector3()) ) as GameObject;
			bugsP2[i] = bugPoolP2[i].GetComponent<Bug>();
			//			spheres[i].Init(i, _position,sphereColors[i]);
			//			spheres[i].SphereSelectionEvent += OnSphereClicked;
		}
	}

}

