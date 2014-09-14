using UnityEngine;
using System.Collections;

public class Bug : MonoBehaviour {

//	public Vector3 position;
//	public Vector3 rotation;
	public Vector3 velocity;
	public int owner;
	public int id; // 0-4 for now

	Transform _transform; //cache

	private int target;

	// properties
	public int Target{
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

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
