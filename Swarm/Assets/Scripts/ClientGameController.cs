using UnityEngine;
using System.Collections;

public class ClientGameController : GameController {

	// The player controllers prefab
	public GameObject HumanPf;
	public GameObject RemoteHumanPf;

	// Use this for initialization
	protected override void Start () {
		Debug.Log("Started ClientGameController");
		base.Start();

		// Left player is remote
		GameObject remoteClone = (GameObject)Instantiate (RemoteHumanPf);
		RemoteHuman remoteHuman = remoteClone.GetComponent<RemoteHuman> ();
		remoteHuman.setTarget (players [0]);

		// Right player is human
		GameObject humanClone = (GameObject)Instantiate (HumanPf);
		Human human = humanClone.GetComponent<Human> ();
		human.setTarget (players [1]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
