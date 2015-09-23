using UnityEngine;
using System.Collections;

public class ReverseArrow : MonoBehaviour {



	public void OnLookEnter()
	{
		transform.Rotate(0,0,180);
	}
}
