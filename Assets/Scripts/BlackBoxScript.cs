using UnityEngine;
using System.Collections;

public class BlackBoxScript : MonoBehaviour {

	public void OnLookEnter()
	{
		Application.LoadLevel (0);
		Screen.showCursor = true;
		RoomCounter.numExits = 0;
		RoomCounter.numRooms = 0;
	}
}
