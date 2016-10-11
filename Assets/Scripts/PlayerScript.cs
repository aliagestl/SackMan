using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {
	GameManager gm;
	GameScript level;

	public GameObject player;
	public GameObject plrSpawn;
	Vector3 moveDirection;
	Vector3 currentPos;
	Vector3 moveTarget;

	float moveSpeed= 4f;


	//List<GameObject> inventory;
	//int maxInventorySlots;
	//int activeItemIndex=0;
	GameObject item=null;



	// Use this for initialization
	void Start () {
		level = GameObject.Find("LEVEL_1").GetComponent<GameScript>();
		gm = GameObject.Find("GM").GetComponent<GameManager>();

		//setup player
		plrSpawn = GameObject.Find("plrSpawn");
		player = GameObject.Find ("player");
		player.transform.position = plrSpawn.transform.position;

	}

	//move character towards marker
	void moveToMarker(){
		//get character to move towards cursor marker
		currentPos = player.transform.position;
		Vector3 moveToward = level.GetComponent<GameScript>().marker.transform.position;
		moveDirection = moveToward - currentPos;
		Vector2 dir = moveToward - currentPos;
		moveDirection.z = 0; 
		moveDirection.Normalize ();

		//move character
		if (dir.magnitude > 0.1f) {
			moveTarget = moveDirection * moveSpeed + currentPos;
			player.transform.position = Vector3.Lerp (currentPos, moveTarget, Time.deltaTime);
		}
	}

	//place an item at aan item point. called by item point messege
	void placeActiveItem(GameObject itemPoint){
		//check dist from spawn point
		currentPos = player.transform.position;
		Vector3 moveToward = itemPoint.transform.position;
		moveDirection = moveToward - currentPos;

		//if close to point
		if(moveDirection.magnitude<1){
			itemPoint.GetComponent<ItemPoint>().AddItem("purplePot");
		}
	}
	
	//place item down anywhere
	void placeActiveItem(){
			//instantiate item in level
			//GameObject item =(GameObject)Instantiate(inventory[activeItemIndex], transform.position, Quaternion.identity);
			//item.transform.parent=(GameObject.Find("LEVEL_1").transform);
	}

	//add item to inventory
	public void AddItem(string itemType){
		if (itemType == "purplePot") {
			item = GameObject.Find ("GM").GetComponent<GameManager> ().purplePot;
		} else if (itemType == "orangePot") {
			item = GameObject.Find ("GM").GetComponent<GameManager> ().orangePot;
		}
		item.transform.parent = (GameObject.Find ("LEVEL_1").transform);
	}

	//check collisions
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("colliding with "+ other.name);
		if (other.gameObject.CompareTag ("Pot"))
		{
			other.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (isActiveAndEnabled) {
			moveToMarker();

			if (Input.GetKeyDown(KeyCode.Space) ) {
				placeActiveItem();
			}

		}
	}
}
















