using UnityEngine;
using System; // for event handler
using System.Collections;

// Handle common LOCAL functionality
public abstract class GameController : MonoBehaviour {
	public const int NUMBER_OF_PLAYERS = 2;
	public const int NUMBER_OF_BUGS = 5;

	protected GameObject[] playerPool;
	protected Player[] players;

	// The game state
	protected GameState gs;

	protected GameObject[] bugPool;
	protected Bug[] bugs;

	protected Vector3[] initialBugPositions;  // TBD may be replaceable after planning phase set.

	// prefabs
	public GameObject playerPf;
	public GameObject bugPf;

	// Listeners
	protected virtual void OnCommand(object sender, CommandEventArgs eventArgs){
		// Determine Command

		// Validate Command

		// Execute Command
	
	}
	protected void OnCommit(){;}


	protected void InstantiateBugs(){
		//  Object instantiate these fellas.
		for (int i=0; i < NUMBER_OF_BUGS; i++){
			bugPool[i] = Instantiate(bugPf,initialBugPositions[i], Quaternion.Euler(new Vector3()) ) as GameObject;
			bugs[i] = bugPool[i].GetComponent<Bug>();
		}
	}

	// Use this for initialization
	protected virtual void Start () {
		Debug.Log("GC Start");
		gs = GameState.getInstance ();

		// HARDCODE
		gs.State = MatchState.COMMANDING;

		bugPool = new GameObject[AppSettings.NUMBER_OF_BUGS];
		bugs = new Bug[AppSettings.NUMBER_OF_BUGS];

		initialBugPositions = new Vector3[AppSettings.NUMBER_OF_BUGS];

		initialBugPositions[0] = new Vector3(-8f,0f,0f);
		initialBugPositions[1] = new Vector3(-4f,0f,0f);
		initialBugPositions[2] = new Vector3(0f,0f,0f);
		initialBugPositions[3] = new Vector3(4f,0f,0f);
		initialBugPositions[4] = new Vector3(8f,0f,0f);
		InstantiateBugs();

		initialBugPositions[0] = new Vector3(-8f,5f,0f);
		initialBugPositions[1] = new Vector3(-4f,5f,0f);
		initialBugPositions[2] = new Vector3(0f,5f,0f);
		initialBugPositions[3] = new Vector3(4f,5f,0f);
		initialBugPositions[4] = new Vector3(8f,5f,0f);
		InstantiateBugs();
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
