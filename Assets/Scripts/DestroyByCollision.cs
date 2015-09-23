using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
