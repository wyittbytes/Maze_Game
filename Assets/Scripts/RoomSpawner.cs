using UnityEngine;
using System.Collections;



public class RoomSpawner : MonoBehaviour 
{
	public string doorType; 	//door A or B
	//public string doorDirection; //	N, S, E, W

	public static int spent;
	public static int exists;

	private Transform roomToSpawn;
	private bool created;	//has spawner been used
	private RoomSelector roomSelector;

	private bool called;

	private bool foundExit;

	private Collider[] checkSpace;

	public bool blocked;

	void Start () 
	{
		blocked = false;
		created = false;	//spawner has not been used
		GameObject gameControllerObject = GameObject.FindWithTag ("RoomSelector");
		roomSelector = gameControllerObject.GetComponent<RoomSelector>();
		exists++;
	}

	void Update()
	{
		checkSpace = Physics.OverlapSphere (transform.position, 2.0f);
		if (checkSpace.Length != 0)
		{

			if(checkSpace[0].tag == "Exit")
			{
				if (!created)
				{
					roomToSpawn = roomSelector.SelectRoom (doorType + "E");
					Instantiate (roomToSpawn, transform.position, transform.rotation);
				}
			}
			else{
				blocked = true;
			}
			created = true;
			IsSpent();
		}
	}

	void OnTriggerEnter(Collider other)
	{

		//Collider[] checkSpace = Physics.OverlapSphere (transform.position, 2.0f);

		if(other.gameObject.tag == "Player")
		{
			/*if (checkSpace.Length != 0)
			{
				created = true;
			}*/

			if(created == true)
			{
				return;
			}

			roomToSpawn = roomSelector.SelectRoom (doorType);
			Instantiate (roomToSpawn, transform.position, transform.rotation);
			created = true;
			IsSpent();
			//Destroy(gameObject);
		}


	}
	void IsSpent()
	{
		if (!called) {
			spent++;
			called = true;
		}
	}

}
/*



function OnTriggerExit (other : Collider) {

	if (other.gameObject.tag == "Player")
     	{
         	Invoke("KillExitRoom", 2);
     	}
     	
}

function KillExitRoom () {

	 Destroy(transform.parent.gameObject);

}
*/