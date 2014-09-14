using UnityEngine;
using System; // for event handler
using System.Collections;


//public class BugSelectEventArgs : EventArgs{
//	public int owner;
//	public int bugId; //source bug
//	public BugState bugState;
//}

public enum BugState{
	ALIVE,
	DEAD,
}

public class Bug : MonoBehaviour {

//	public Vector3 position;
//	public Vector3 rotation;
	public Vector3 velocity;
	public int owner;
	public int id; // 0-4 for now

	protected Transform _transform; //cache
	protected BugState bugState;

	public delegate void BugSelectHandler(object sender);
	public event BugSelectHandler BugSelectEvent;

	public bool IsDead(){
		return (bugState == BugState.DEAD);
	}

	private Bug target;
	// properties
	public Bug Target{ // Sets a ref, does NOT COPY
		get{
			return target;
		}
		set{
			target = value;
		}
	}

	public Vector3 Position{
		get{
			return _transform.position;
		}
		set{
			_transform.position = value;
		}
	}

	public Quaternion Rotation{
		get{
			return _transform.rotation;
		}
		set{
			_transform.rotation = value;
		}
	}

	public Bug(Vector3 _position){
		Position = _position;
	}

	// Behavior
	public void Move(Vector3 targetPosition){

	}

	public void Move(Bug targetBug){
		
	}

	public void Shoot(){

	}

	public void OnHit(){

	}

	public void Die(){

	}

	void OnMouseUp(){
//		BugSelectEventArgs bsea = new BugSelectEventArgs();
//		bsea.bugId = id;
//		bsea.owner = owner;
//		bsea.bugState = bugState;
//		BugSelectEvent(this, bsea);
		BugSelectEvent(this);
	}

	// Use this for initialization
	void Start () {
		_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
