using UnityEngine;
using System.Collections;

/// <summary>
/// The states of the game
/// </summary>
public enum GameStates
{
	/// <summary>
	/// During this state, the players choose the bugs
	/// </summary>
	PLANNING,
	
	/// <summary>
	/// During this state, the players choose their commands
	/// </summary>
	COMMANDING,
	
	/// <summary>
	/// During this state, the swarm moves 
	/// </summary>
	ACTION,
	
	/// <summary>
	/// During this state, the results of the match are shown
	/// </summary>
	END
}

// This signleton class contains the current state of the game
// The idea is to keep this class always synced between client and server
public class GameState{
	
	// The singleton instance
	private GameState instance;

	// Private constructor
	private GameState(){
		
	}

	// Get the current instance or create the game state
	public static GameState getInstance(){
		if (instance == null)
			instance = new GameState ();
		return instance;
	}
}
