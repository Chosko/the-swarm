using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The states of the game
/// </summary>
public enum MatchState
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
	private static GameState instance;

	// vars
	private MatchState state;
	private LinkedList<PlayerController> observers;

	// Private constructor
	private GameState(){
		State = MatchState.PLANNING;
		observers = new LinkedList<PlayerController>();
	}

	public void AddObserver(PlayerController pc){
		observers.AddFirst (pc);
	}

	// Get the current instance or create the game state
	public static GameState getInstance(){
		if (instance == null)
			instance = new GameState ();
		return instance;
	}

	// Destroys the current instance. To call before starting the game
	public static GameState destroyInstance(){
		instance = null;
	}

	public MatchState State {
		get{
			return state;
		}

		set{
			state = value;
			foreach (PlayerController pc in observers) {
				switch(value){
					case MatchState.PLANNING:
						pc.PlanningStarted();
						break;
					case MatchState.COMMANDING:
						pc.CommandingStarted();
						break;
					case MatchState.ACTION:
						pc.ActionStarted();
						break;
					case MatchState.END:
						pc.EndStarted();
						break;
					default:
						break;
				}
			}
		}
	}
}
