using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	protected Player player;
	protected GameState gs;

	// Use this for initialization
	void Start () {
		gs = GameState.getInstance ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Called when the PLANNING state starts
	public virtual void PlanningStarted(){

	}

	// Called when the COMMANDING state starts
	public virtual void CommandingStarted(){

	}

	// Called when the ACION state starts
	public virtual void ActionStarted(){

	}

	// Called when the END state starts
	public virtual void EndStarted(){

	}

	/// <summary>
	/// Sets the target player for this controller.
	/// </summary>
	/// <param name="targetPlayer">Target player.</param>
	public void setTarget(Player targetPlayer){
		player = targetPlayer;
	}
}
