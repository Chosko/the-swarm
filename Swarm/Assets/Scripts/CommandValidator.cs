using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class CommandValidator : MonoBehaviour {

	enum SelectionState{
		Idle,
		SourceSelected,
		Complete
	};

	private SelectionState selectionState;
	private Bug source;

	public void RegisterBug(Bug bug){
		bug.BugSelectEvent += OnBugSelected;
	}

	private void OnFieldSpaceSelected(object sender){
		Command command = new Command();
		command.source = source;
		command.commandType = CommandType.SENTRY;
	}

	private void OnBugSelected(object sender){
		Bug bugSender = sender as Bug;

		if (bugSender.IsDead()){
			// Send error message.
			return;
		}

		switch (selectionState){

		case SelectionState.Idle:{
			source = bugSender;
			selectionState = SelectionState.SourceSelected;
			break;
		}

		case SelectionState.SourceSelected:{
			Command command = new Command();

			// if enemy selected, create attack
			if (source.owner != bugSender.owner){
				command.commandType = CommandType.ATTACK;
			}
			// if own selected, create defend
			else {
				command.commandType = CommandType.DEFEND;
			}

			command.source = source;
			command.target = bugSender;
			selectionState = SelectionState.Complete;
			break;
		}

		case SelectionState.Complete:{


			break;
		}

		default:{
			Debug.LogError("Unhandled Selectionstate");
			break;
		}
		}//end switch

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
