var objectScale : float = 1.0;
var decreaseAmount : float = 0.01;
var increment : boolean = false;


function Update () {

	//if(!increment)
		//{
			transform.localScale.y = objectScale;
		//}
		
	//if(increment)
		//{
			//transform.localScale.y = Mathf.Round(objectScale * 100f) / 100f;
		//}
	
	
	if (objectScale <= 0.15)
     	{
         	Destroy (gameObject);
     	}	

}

function OnTriggerStay (other : Collider) {

	//Debug.Log ("Collision Detected!");

	if (other.gameObject.tag == "Player")
     	{
         	objectScale -= decreaseAmount;
     	}	
		
}