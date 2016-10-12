using UnityEngine;
using System.Collections;

public class HideTile : MonoBehaviour {

	PlayerScript player;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("player").GetComponent<PlayerScript>();

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other){

		Debug.Log ("player is on Hide Tile");
		//check to see if player is colliding with this Hide Tile
		if (other.gameObject.CompareTag ("Player")) {
			player.playerHiding = true;
		} 
	}
	void OnTriggerExit2D(Collider2D other){

		Debug.Log ("Player has left the Hide Tite");
		if(other.gameObject.CompareTag("Player")){
			player.playerHiding = false;
		}
	}
}
