using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {
	public string itemType;
    public string color;

	public bool isMouseOver;
	public bool isPlayerOver;

	// Use this for initialization
	void Start () {
	
	}

	//check collisions enter
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("colliding with "+ other.name);
		if (other.gameObject.CompareTag ("Player")) {
			isPlayerOver = true;
		}
		if(other.gameObject.CompareTag ("Cursor")){
			isMouseOver=true;
		}
	}
	//check collisions exit
	void OnTriggerExit2D(Collider2D other) 
	{
		Debug.Log ("now not colliding with "+ other.name);
		if (other.gameObject.CompareTag ("Player")) {
			isPlayerOver = false;
		}
		if(other.gameObject.CompareTag ("Cursor")){
			isMouseOver=false;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
