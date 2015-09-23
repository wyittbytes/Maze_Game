// Pulse light's intensity over time.
var range : float = 8.0;
var rangeMin : float = 0.0;
var rangeMax : float = 8.0;

var flickerSpeed : float = 0.1;

var lt: Light;


function Start() {

	lt = GetComponent.<Light>();
	
	Invoke("Change_Flicker", flickerSpeed);
	
}


function Update() {	

	lt.intensity = range;
	
}

function Change_Flicker() {

	range = Mathf.Ceil(Random.Range(rangeMin, rangeMax));
	
	Invoke("Change_Flicker", flickerSpeed);

}