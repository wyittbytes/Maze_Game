using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{

	public GUIText roomText;		//var to attach score GUI
	public GUIText restartText;		//var to attach restart GUI
	public GUIText gameOverText;	//var to attach game over GUI

	private bool restart;			//var is game restart
	private int prevNum;
	private bool done;

	void Start()
	{
		//gameOver = false;		//game not over
		restart = false;		//game not restart
		restartText.text = "";	//restart blank
		gameOverText.text = "";	//game over blank
		prevNum = 0;
		UpdateRooms(); 			//sets score to zero
		done = false;
	
	}


	void Update () 
	{


		if (RoomCounter.numRooms > prevNum)
		{
			UpdateRooms();
			prevNum = RoomCounter.numRooms;
		}


		if(RoomSpawner.exists == RoomSpawner.spent || Application.loadedLevel > 1)
		{
			if(!done)
			{
				GameOver();
			}
		}

		if (restart)	//if game ready for restart
		{
			//hitting 'r' will reload level
			if(Input.GetKeyDown(KeyCode.T))
			{
				Application.LoadLevel(Application.loadedLevel);
				RoomCounter.numExits = 0;
				RoomCounter.numRooms = 0;
			}
		}

		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}


	}

	void UpdateRooms()
	{
		roomText.text = "Rooms Located: " + RoomCounter.numRooms; 
	}

	void GameOver()
	{
		if(Application.loadedLevel == 1)
		{
			gameOverText.text = "Congratulations! You found " + RoomCounter.numRooms + " Rooms and " + RoomCounter.numExits + " Exits!";
			restartText.text = "Press 'T' to Try Again";
			restart = true;
		}

		if(Application.loadedLevel == 2)
		{
			gameOverText.text = "Congratulations! You found the Blue Room. Please don't touch the Black Box.";
			Invoke("BlankText",3f);
			done = true;
		}
		if(Application.loadedLevel == 3)
		{
			gameOverText.text = "Congratulations! You found the Red Room. Please touch the Black Box.";
			Invoke("BlankText",3f);
			done = true;
		}
	}

	public void Begin()
	{
		Application.LoadLevel (1);
	}

	public void End()
	{
		Application.Quit();
	}

	void BlankText()
	{
		gameOverText.text = "";	//game over blank
	}

	public void LockedDoor()
	{
		gameOverText.text = "Locked";	//game over blank
		Invoke ("BlankText", 3f);
	}

}
