using UnityEngine;
using System.Collections;

public class RoomCounter : MonoBehaviour 
{

	public static int numRooms;
	public static int numExits;

	public bool isExit = false;

	void Start () 
	{
		if(!isExit)
		{
			numRooms++;
		}
		else
		{
			numExits++;
		}
	}
	

}
