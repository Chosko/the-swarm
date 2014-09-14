using UnityEngine;
using System; // for event handler
using System.Collections;

// Handle common LOCAL functionality
public abstract class GameController : MonoBehaviour {

	public const int NUMBER_OF_PLAYERS = 2;
	private Player[] players;

	// Listeners
	protected virtual void OnCommand(object sender, CommandEventArgs eventArgs){;}
	protected void OnCommit(){;}

	// Use this for initialization
	void Start () {
		players = new Player[NUMBER_OF_PLAYERS];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
