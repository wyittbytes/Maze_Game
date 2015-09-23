using UnityEngine;
using System.Collections;



public class RoomSelector : MonoBehaviour {


	public Transform[] aList;
	public Transform[] bList;

	public Transform aExit;
	public Transform bExit;

	private int rand;
	private int randMin;
	private int randMax;

	private Transform thisRoom;

	void Start()
	{ 
		rand = 1;
		randMin = 0;

	}

	public Transform SelectRoom(string doorType)	//doorType is A or B
	{

		if(doorType != "A" && doorType != "B" && doorType != "AE" && doorType != "BE")
		{
			Debug.Log("Door Type Invalid");
		}

		if(doorType == "A")
		{
			rand = Random.Range (randMin, aList.Length);
			thisRoom = aList[rand];				
		}

		if(doorType == "B")
		{
			rand = Random.Range (randMin, bList.Length);
			thisRoom = bList[rand];
		}

		if (doorType == "AE")
		{
			thisRoom = aExit;
		}

		if (doorType == "BE")
		{
			thisRoom = bExit;
		}

		return thisRoom;
	}



}
/*



function OnTriggerEnter (other : Collider) {

	rand = Random.Range(randMin, randMax);

	if (other.gameObject.tag == "Player")
     	{
     		if (rand == 1)
     			{
     				Instantiate(roomToSpawn1, transform.position, transform.rotation);
     			}
         	if (rand == 2)
     			{
     				Instantiate(roomToSpawn2, transform.position, transform.rotation);
     			}
     		if (rand == 3)
     			{
     				Instantiate(roomToSpawn3, transform.position, transform.rotation);
     			}
     	}
     	
}

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