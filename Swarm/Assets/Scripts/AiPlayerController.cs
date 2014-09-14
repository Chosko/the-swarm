using UnityEngine;
using System.Collections;

public class AiPlayerController : PlayerController {

	// Use this for initialization
	protected override void Start () {
		Debug.Log("AI Start");
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Called as the MatchState changes to PLANNING
	protected override void PlanningStarted ()
	{
		base.PlanningStarted ();

		// TODO: Make the AI choose all his bugs.
	}
}
