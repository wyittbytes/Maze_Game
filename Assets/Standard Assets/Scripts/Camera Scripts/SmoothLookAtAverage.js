var target : Transform;

var player1 : Transform;
var player2 : Transform;

var damping = 2.0;
var smooth = true;

var distanceAveraging = 1.0;
var cameraDistance = 4;
var height = 2.0;
var heightDamping = 2.0;
var sideDamping = 2.0;

@script AddComponentMenu("Camera-Control/Smooth Look At")

function LateUpdate () {

		var wantedHeight = target.position.y + height;
		var currentHeight = transform.position.y;
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		transform.position.y = currentHeight;
		
		var wantedSidePOS = target.position.x;
		var currentSidePOS = transform.position.x;
		currentSidePOS = Mathf.Lerp (wantedSidePOS, currentSidePOS, sideDamping * Time.deltaTime);
		transform.position.x = currentSidePOS/sideDamping;
		
		distanceAveraging = Vector3.Distance(player1.position, player2.position);
		

			
		transform.position.z = target.position.z;
		transform.position.z -= distanceAveraging + cameraDistance;


	if (target) {
		if (smooth)
		{
			// Look at and dampen the rotation
			var rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		}
		else
		{
			// Just lookat
		    transform.LookAt(target);
		}
	}
}

function Start () {
	// Make the rigid body not change rotation
   	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}

