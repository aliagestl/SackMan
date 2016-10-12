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
	public bool playerHiding;

	public GameObject item=null;
	public bool hasItem{get{ if(item != null)return true; else return false;}}

	GameObject RIcon;
	GameObject YIcon;
	GameObject r_pot;
	GameObject y_pot;

	// Use this for initialization
	void Start () {
		level = GameObject.Find("LEVEL_1").GetComponent<GameScript>();
		gm = GameObject.Find("GM").GetComponent<GameManager>();

		RIcon=GameObject.Find ("redPotIcon");
		YIcon=GameObject.Find ("yellowPotIcon");
		r_pot=GameObject.Find ("plrRedPot");
		y_pot=GameObject.Find ("plrYellowPot");



		//setup player
		plrSpawn = GameObject.Find("plrSpawn");
		player = GameObject.Find ("player");
		player.transform.position = plrSpawn.transform.position;
		playerHiding = false;

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
		if (dir.magnitude > 1f) {
			moveTarget = moveDirection * moveSpeed + currentPos;
			player.transform.position = Vector3.Lerp (currentPos, moveTarget, Time.deltaTime);
		}
	}

	//place an item at an item point. called by item point messege
	void interactWithPoint(GameObject itemPoint){
		if (item != null) {
			//check dist from spawn point
			currentPos = player.transform.position;
			Vector3 moveToward = itemPoint.transform.position;
			moveDirection = moveToward - currentPos;

			//if close to point
			if (moveDirection.magnitude < 1.5f) {
				Debug.Log ("player is in range");
				//if current held item belongs on that point
				if (item.name == itemPoint.GetComponent<ItemPoint> ().itemType) {
					if(itemPoint.GetComponent<ItemPoint> ().hasItem==false){
					itemPoint.GetComponent<ItemPoint> ().ShowItem ();
					//---> add code to add to inventory
					removeItem();
					gm.score+=10;
					Debug.Log("placed item");
					}
					else { Debug.Log("there already is an item there..."); }
				}
			}
		} else {
			//check dist from spawn point
			currentPos = player.transform.position;
			Vector3 moveToward = itemPoint.transform.position;
			moveDirection = moveToward - currentPos;
			//if close to point
			if (moveDirection.magnitude < 1.5f) {
				Debug.Log ("player is in range");
				if(itemPoint.GetComponent<ItemPoint>().hasItem){
				itemPoint.GetComponent<ItemPoint> ().HideItem();
				//---> add code to add to inventory
					AddItem(itemPoint.GetComponent<ItemPoint> ().itemType);
				Debug.Log("took item");
				}
				else {Debug.Log("there is no item to take...");}

			}
		}
	}

	//place an item at an item point. called by item point messege
	void getPot(GameObject storageSpot){
//		if (item != null) {
//			Debug.Log ("you're already holding an item...");
//		} else {
			//check dist from spawn point
			currentPos = player.transform.position;
			Vector3 moveToward = storageSpot.transform.position;
			moveDirection = moveToward - currentPos;
			//if close to point
			if (moveDirection.magnitude < 1.5f) {
				Debug.Log ("player is in range");
				//---> add code to add to inventory
				removeItem();
				AddItem (storageSpot.GetComponent<StorageSpot> ().itemType);
				Debug.Log ("took item");
			} else {
				Debug.Log ("there is no item to take...");
			}
//		}
	}


	//add item to inventory
	public void AddItem(string itemType){
		if (itemType == "redPot") {
			item = GameObject.Find ("redPot");
		} else if (itemType == "yellowPot") {
			item = GameObject.Find ("yellowPot");
		}
	}

	void removeItem(){
		item=null;
	}

	//check collisions
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("colliding with "+ other.name);
		if (other.gameObject.CompareTag ("Pot"))
		{
			//other.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (isActiveAndEnabled) {
			moveToMarker();

			if (Input.GetKeyDown(KeyCode.Space) ) {
				//placeActiveItem();
			}

			//update icon
			if(item!=null){
				if(item.name=="redPot"){
					RIcon.SetActive(true);
					YIcon.SetActive(false);
					r_pot.SetActive(true);
					y_pot.SetActive(false);
				}
				else if(item.name=="yellowPot"){
					RIcon.SetActive(false);
					YIcon.SetActive(true);

					r_pot.SetActive(false);
					y_pot.SetActive(true);
				}
			}
			else{
				RIcon.SetActive(false);
				YIcon.SetActive(false);
				r_pot.SetActive(false);
				y_pot.SetActive(false);
			}

			//kill player if no time is left and they are not hiding
			if(gm.timeLeft < 0 && playerHiding == false)
			{
				this.gameObject.SetActive(false);
				gm.playerAlive = false;
			}
		}
	}
}
















