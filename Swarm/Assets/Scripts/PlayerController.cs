using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	protected Player player;
	protected GameState gs;

	// Use this for initialization
	void Start () {
		gs = GameState.getInstance ();
		gs.OnPlanningStarted += PlanningStarted;
	    gs.OnCommandingStarted += CommandingStarted;
	    gs.OnActionStarted += ActionStarted;
	    gs.OnEndStarted += EndStarted;

	    // Call for the first time the event, because the playercontroller is created after
	    switch(gs.State){
			case MatchState.PLANNING:
				PlanningStarted();
				break;
			case MatchState.COMMANDING:
				CommandingStarted();
				break;
			case MatchState.ACTION:
				ActionStarted();
				break;
			case MatchState.END:
				EndStarted();
				break;
			default:
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Called when the PLANNING state starts
	public virtual void PlanningStarted(){
		Debug.Log("PlanningStarted called on PlayerController");
	}

	// Called when the COMMANDING state starts
	public virtual void CommandingStarted(){
		Debug.Log("CommandingStarted called on PlayerController");
	}

	// Called when the ACION state starts
	public virtual void ActionStarted(){
		Debug.Log("ActionStarted called on PlayerController");
	}

	// Called when the END state starts
	public virtual void EndStarted(){
		Debug.Log("EndStarted called on PlayerController");
	}

	/// <summary>
	/// Sets the target player for this controller.
	/// </summary>
	/// <param name="targetPlayer">Target player.</param>
	public void setTarget(Player targetPlayer){
		player = targetPlayer;
	}
}
