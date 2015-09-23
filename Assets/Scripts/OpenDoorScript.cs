using UnityEngine;
using System.Collections;

public class OpenDoorScript : MonoBehaviour 
{

	private float xAdjust = 0f;
	private float zAdjust = 0f;
	public bool locked;
	private bool open;
	private string[] m_AnimNames;
	private bool byDoor;
	private int roomRotation;

	private GameController gameController;	//variable linking to game controller

	private AudioSource openAudio;		//audio for shot
	private AudioSource lockedAudio;		//audio for dead

	void Start () 
	{ 

		//finds game controller to connect for game over and scoring
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)	//if game controller exists
		{
			//connects to game controller
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		//if game controller cannot be found prints error
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}

		roomRotation = (int)transform.eulerAngles.y;
		Debug.Log (roomRotation);
		locked = false;
		open = false;
		byDoor = false;
		m_AnimNames = new string[animation.GetClipCount()];
		int index = 0;
		foreach(AnimationState anim in animation)
		{
			m_AnimNames[index] = anim.name;
			index++;
		}
		FixRotation ();

		AudioSource[] audios = GetComponents<AudioSource> ();
		openAudio = audios [0];	
		lockedAudio = audios [1];	
	}
	
	void Update()
	{

		Vector3 vect = new Vector3 (transform.position.x + xAdjust, 1.3f, transform.position.z + zAdjust);
		Collider[] checkSpace = Physics.OverlapSphere (vect, 0.5f);

		if (checkSpace.Length != 0)
		{
			if(checkSpace[0].tag == "Room")
			{
				locked = true;
			}
		}

		if(open != true && byDoor == true)
		{
			if (Input.GetKeyDown (KeyCode.E))
			{
				if(locked == true)
				{
					Debug.Log ("Door is locked");
					lockedAudio.Play ();
					return;
				}

				Debug.Log ("E");
				animation.Play (m_AnimNames[0]);
				openAudio.Play ();
				open = true;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			byDoor = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			byDoor = false;
		}
	}

	void FixRotation()
	{
		switch(roomRotation)
		{
		case 0:
			xAdjust = -0.8f;
			break;
		case 90:
			zAdjust = 0.8f;
			break;
		case 180:
			xAdjust = 0.8f;
			break;
		case 270:
			zAdjust = -0.8f;
			break;
		}

	}
	public void OnLookEnter()
	{
		if(open != true && byDoor == true)
		{
			if(locked == true)
			{
				Debug.Log ("Door is locked");
				gameController.LockedDoor();
				lockedAudio.Play ();
				return;
			}

			Debug.Log ("E");
			animation.Play (m_AnimNames[0]);
			openAudio.Play ();
			open = true;

		}
	}

}
