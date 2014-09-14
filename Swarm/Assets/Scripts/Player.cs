using UnityEngine;
using System; // for event handler
using System.Collections;


public class Player : MonoBehaviour {  // CRINGE!  Don't really need it to be a monobehavior, but easier than passing PF from GameController

	public Color color;
	private Command[] commands;

	protected Bug[] bugs=null;
	public Bug[] Bugs{
		get{
			return bugs;
		}
		set{
			bugs = (Bug[])value.Clone();
		}
	}


	public Player(){
		commands = new Command[AppSettings.NUMBER_OF_BUGS];
	}

	public void StartInit(){
	}

	protected virtual void Start () {
		Debug.Log("Player Start()");
	}

}

