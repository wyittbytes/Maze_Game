using UnityEngine;
using System.Collections;

public class CollectibleSpawner : MonoBehaviour 
{

	public Transform[] collectible;
	private int rand;

	void Start () 
	{
		rand = Random.Range (0, collectible.Length);
		Instantiate (collectible [rand], transform.position, transform.rotation);
	}

}
