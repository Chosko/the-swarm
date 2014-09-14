using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	
	int bugNumber			= 0;				// Number, in order, of bugs selected (0-4)
	GameObject[] bugPrefab;						// Array containing bug prefabs
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void  ChooseEnemyBugs (){
		for(int i = 0; i < 5; i++)
		{
			Random random = new Random();
			// Instantiate a random bug to each spot.
			
			
			Bug tempEnemyBug = Player.bugsP2;
			
			tempEnemyBug.GetComponent<Bug>().bugID 			= i;
			tempEnemyBug.GetComponent<Bug>().isP2			= 1;
			tempEnemyBug.tag 								= "enemyBug";			// set the tag on this object to "Player Bug"
		}
	}
	
	void  ChooseEnemyActions (Vector3 new enemyPatrolPos[]){
		Bug tempTarget;
		for(int i = 0; i < 5; i++)
		{
			// Instantiate a random bug to each spot.
			Random random = new Random();
			int randomActionNumber = random.Next(1, 6);		// 1 = Attack, 2 = Patrol, 3 = Defend, 4+ = Attack Flag
			Debug.Log("Random Number is: " + randomActionNumber);
			if (randomActionNumber == 1)					// Enemy will attack
			{
				tempTarget = Player.bugsP1[random.Next(0,4)];
				Player.bugsP2[i].target = tempTarget;
			}
			if (randomActionNumber == 2)
			{
				tempTarget = enemyPatrolPos[random.Next(0,enemyPatrolPos.Length)]]; //Pass Patrol Position to Target
				Player.bugsP2[i].target = tempTarget;
			}
			if (randomActionNumber == 3)
			{
				int defendID = i;
				Bug selectedBug;
				while ((defendID == i) || selectedBug.target == Player.bugsP2[i])
				{
					defendID = random.Next(0,5);		// Choose a new ID #.  If it's still the same as i, will repeat.
					selectedBug = Player.bugsP2[defendID];
				}
				Player.bugsP2[i].target = selectedBug;
			}
			if (randomActionNumber >= 4)
				tempTarget = Player.flagP1;
			Player.bugsP2[i].target = tempTarget;
		}
	}
	
	
}
