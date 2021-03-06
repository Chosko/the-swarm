﻿using UnityEngine;
using System.Collections;

public class OfflineGameController : GameController {

	// The player controllers prefab
	public GameObject AIPf;
	public GameObject HumanPf;

  	// Use this for initialization
	protected override void Start () {
		Debug.Log("Started OfflineGameController");
		base.Start();

		// Left player is human
		GameObject humanClone = (GameObject)Instantiate (HumanPf);
		HumanPlayerController human = humanClone.GetComponent<HumanPlayerController> ();
		human.setTarget (players [0]);

		// Right player is AI
		GameObject aiClone = (GameObject)Instantiate (AIPf);
		AiPlayerController ai = aiClone.GetComponent<AiPlayerController> ();
		ai.setTarget (players [1]);
	}
  
	// Update is called once per frame
 	void Update () {
  		
	}
}
