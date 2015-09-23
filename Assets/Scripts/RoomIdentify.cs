using UnityEngine;
using System.Collections;

public class RoomIdentify : MonoBehaviour {

	private RoomDestroyer roomDestroyer;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("RoomDestroy");
		roomDestroyer = gameControllerObject.GetComponent<RoomDestroyer>();
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			roomDestroyer.currentRoom = gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			roomDestroyer.prevRoom = gameObject;
		}
	}
}
