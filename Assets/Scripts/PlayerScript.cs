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
	Vector3 target;
	float moveSpeed= 4f;


	List<GameObject> inventory;
	int maxInventorySlots;
	int activeItemIndex=0;
	GameObject item;

	// Use this for initialization
	void Start () {
		level = GameObject.Find("LEVEL_1").GetComponent<GameScript>();
		gm = GameObject.Find("GM").GetComponent<GameManager>();

		//setup player
		plrSpawn = GameObject.Find("plrSpawn");
		player = GameObject.Find ("player");
		player.transform.position = plrSpawn.transform.position;

		//setup inventory
		inventory= new List<GameObject>();
		maxInventorySlots = 2;
		AddItem ("redPot");
	}

	//move character towards marker
	void moveToMarker(){
		//get character to move towards cursor marker
		currentPos = player.transform.position;
		Vector3 moveToward = level.GetComponent<GameScript>().cursor.transform.position;
		moveDirection = moveToward - currentPos;
		Vector2 dir = moveToward - currentPos;
		moveDirection.z = 0; 
		moveDirection.Normalize ();

		//move character
		if (dir.magnitude > 0.1f) {
			target = moveDirection * moveSpeed + currentPos;
			player.transform.position = Vector3.Lerp (currentPos, target, Time.deltaTime);
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
			itemPoint.GetComponent<ItemPoint>().AddItem("yellowPot");
		}
	}
	
	//place item down anywhere
	void placeActiveItem(){
		if(inventory.Count>0){
			//instantiate item in level
			GameObject item =(GameObject)Instantiate(inventory[activeItemIndex], transform.position, Quaternion.identity);
			item.transform.parent=(GameObject.Find("LEVEL_1").transform);
//			//remove from inventory
//			inventory.RemoveAt(activeItemIndex);
//			while(activeItemIndex>inventory.Count-1){
//				activeItemIndex-=1;
//			}
		}
	}

	//add item to inventory
	public void AddItem(string itemType){
		if (itemType == "redPot") {
			item = GameObject.Find ("GM").GetComponent<GameManager> ().redPot;
		} else if (itemType == "yellowPot") {
			item = GameObject.Find ("GM").GetComponent<GameManager> ().yellowPot;
		}
		item.transform.parent = (GameObject.Find ("LEVEL_1").transform);
        item.tag = "pot";
		inventory.Add (item);
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
















