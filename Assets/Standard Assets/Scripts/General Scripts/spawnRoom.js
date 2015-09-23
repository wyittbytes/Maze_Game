var roomToSpawn1 : Transform;
var roomToSpawn2 : Transform;
var roomToSpawn3 : Transform;

var rand : int = 1;
var randMin : int = 1;
var randMax : int = 4;

function Update () {

		//rand = Random.Range(randMin, randMax);

}

function OnTriggerEnter (other : Collider) {

	rand = Random.Range(randMin, randMax);

	if (other.gameObject.tag == "Player")
     	{
     		if (rand == 1)
     			{
     				Instantiate(roomToSpawn1, transform.position, transform.rotation);
     			}
         	if (rand == 2)
     			{
     				Instantiate(roomToSpawn2, transform.position, transform.rotation);
     			}
     		if (rand == 3)
     			{
     				Instantiate(roomToSpawn3, transform.position, transform.rotation);
     			}
     	}
     	
}

function OnTriggerExit (other : Collider) {

	if (other.gameObject.tag == "Player")
     	{
         	Invoke("KillExitRoom", 2);
     	}
     	
}

function KillExitRoom () {

	 Destroy(transform.parent.gameObject);

}