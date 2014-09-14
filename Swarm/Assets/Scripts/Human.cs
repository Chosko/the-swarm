using UnityEngine;
using System.Collections;

public class Human : PlayerController {

	// Use this for initialization
	protected override void Start () {
		Debug.Log("Human Start");
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Called as the MatchState changes to PLANNING
	protected override void PlanningStarted ()
	{
		base.PlanningStarted ();
		
		// TODO: Show a GUI to make the Human choose the bugs
	}
}
