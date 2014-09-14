using UnityEngine;
using System; // for event handler
using System.Collections;

// Handle common LOCAL functionality
public abstract class GameController : MonoBehaviour {

	public const int NUMBER_OF_PLAYERS = 2;

	// prefabs
	public GameObject playerPf;

	protected GameObject[] playerPool;
	protected Player[] players;

	// The game state
	protected GameState gs;

	// Listeners
	protected virtual void OnCommand(object sender, CommandEventArgs eventArgs){;}
	protected void OnCommit(){;}

	// Use this for initialization
	protected virtual void Start () {
		Debug.Log("GC Start");
		gs = GameState.getInstance ();
		players = new Player[NUMBER_OF_PLAYERS];
		playerPool = new GameObject[NUMBER_OF_PLAYERS];

		Vector3 _position = new Vector3(0f,0f,0f); // whatev... change this for a better layout
		for (int i=0; i < NUMBER_OF_PLAYERS; i++){
			playerPool[i] = UnityEngine.GameObject.Instantiate(playerPf, _position, Quaternion.Euler(new Vector3()) ) as GameObject;
			players[i] = playerPool[i].GetComponent<Player>();
			players[i].StartInit(); // instantiate game objectes owned by player
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
