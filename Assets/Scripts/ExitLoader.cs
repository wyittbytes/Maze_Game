using UnityEngine;
using System.Collections;

public class ExitLoader : MonoBehaviour {

	public int[] exits;		// build level of exit 
							// first is A, second is B

	public string type;		// A or B

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if (type == "A")
			{
				Application.LoadLevel(exits[0]);
			}
			if(type == "B")
			{
				Application.LoadLevel(exits[1]);
			}
		}

	}
}
