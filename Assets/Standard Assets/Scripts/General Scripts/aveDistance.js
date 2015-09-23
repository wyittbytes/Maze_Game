var player1 : Transform;
var player2 : Transform;

var averagePostion = Vector3(0, 0, 0);

function Update () {
	
	averagePostion = Vector3(((player1.position.x + player2.position.x)/2), ((player1.position.y + player2.position.y)/2), ((player1.position.z + player2.position.z)/2));
	transform.position = averagePostion;

}