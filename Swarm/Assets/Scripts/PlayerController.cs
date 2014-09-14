using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	protected Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Sets the target player for this controller.
	/// </summary>
	/// <param name="targetPlayer">Target player.</param>
	public void setTarget(Player targetPlayer){
		player = targetPlayer;
	}
}
