using UnityEngine;
using System; // for event handler
using System.Collections;

public enum GameState{
	Planning,
	Commanding,
	Action,
	End
}

// Handle common LOCAL functionality
public abstract class GameController : MonoBehaviour {

	public const int NUMBER_OF_PLAYERS = 2;

	protected Player[] players;

	// Listeners
	protected virtual void OnCommand(object sender, CommandEventArgs eventArgs){;}
	protected void OnCommit(){;}

	// Use this for initialization
	void Start () {
		Debug.Log("GC Start");
		players = new Player[NUMBER_OF_PLAYERS];
		players[0].StartInit(); // instantiate game objectes owned by player

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
