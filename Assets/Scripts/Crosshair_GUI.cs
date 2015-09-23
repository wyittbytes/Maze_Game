using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]

public class Crosshair_GUI : MonoBehaviour {

	public _GUIClasses.TextureGUI crosshair = new _GUIClasses.TextureGUI();
	public _GUIClasses.Location location = new _GUIClasses.Location();
	public GUIStyle noGuiStyle;
	public Color GUIColor = Color.blue;

	public float range = 300.0f;

	public GameObject wallMarker;

	// Use this for initialization
	void Start () 
	{
		useGUILayout = false;
		Screen.showCursor = false;

	}
	
	// Update is called once per frame
	void Update () 
	{	
		location.updateLocation ();

		Ray ray = Camera.main.ScreenPointToRay(new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit = new RaycastHit ();
		Debug.DrawRay (ray.origin, ray.direction, Color.green);
		
		if(Physics.Raycast(ray, out hit, range))
		{
			if(hit.collider.gameObject.GetComponent<ReverseArrow>() != null)
			{

				if(Input.GetMouseButtonDown(0))
				{
					hit.collider.gameObject.GetComponent<ReverseArrow>().OnLookEnter();
				}
			}
			if(hit.collider.gameObject.GetComponent<OpenDoorScript>() != null)
			{
				
				if(Input.GetMouseButtonDown(0))
				{
					hit.collider.gameObject.GetComponent<OpenDoorScript>().OnLookEnter();
				}
			}
			if(hit.collider.gameObject.GetComponent<BlackBoxScript>() != null)
			{
				
				if(Input.GetMouseButtonDown(0))
				{
					hit.collider.gameObject.GetComponent<BlackBoxScript>().OnLookEnter();
				}
			}
			if(hit.collider.gameObject.GetComponent<LockedExitScript>() != null)
			{
				if(Input.GetMouseButtonDown(0))
				{
					hit.collider.gameObject.GetComponent<LockedExitScript>().OnLookEnter();
				}
			}
			if(hit.collider.gameObject.tag == "Room")
			{
				if(Input.GetMouseButton(0))
				{
					Instantiate(wallMarker, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)); 
				}
			}
		}

	}

	void OnGUI()
	{
		GUI.color = GUIColor;
		GUI.Box (new Rect(location.offset.x + crosshair.offset.x,
		                 	location.offset.y + crosshair.offset.y,
		                 	crosshair.texture.width, crosshair.texture.height),
		        		 	crosshair.texture, noGuiStyle);
	}
}
