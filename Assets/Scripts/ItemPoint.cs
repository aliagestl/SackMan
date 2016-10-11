using UnityEngine;
using System.Collections;

public class ItemPoint : MonoBehaviour {

	GameScript gm;

	GameObject item;
	public string type;

	public bool startWithItem;
	public bool hasItem;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find("LEVEL_1").GetComponent<GameScript>();

        //set color of dot to color of pot



		hasItem = false;

		//setup spawn point items
		if (startWithItem) {
			AddItem(type);
		} else {
			hasItem=false;;
		}
	}

	void DetermineItem(){
		if(type=="redPot"){
			item=GameObject.Find("GM").GetComponent<GameManager>().redPot;
		}
		else if(type == "yellowPot"){
			item=GameObject.Find("GM").GetComponent<GameManager>().yellowPot;
		}
	}

	void RemoveItem(){
		hasItem = false;
	}

	void OnMouseOver(){
		//
		if (!hasItem) {
			//AddItem(type);
			gm.player.SendMessage("placeActiveItem",this.gameObject);
		}
	}
	
	public void AddItem(string itemType){
		if (hasItem==false) {
			if (itemType == "redPot") {
				item=GameObject.Find("GM").GetComponent<GameManager>().redPot;
			} else if (itemType == "yellowPot") {
				item=GameObject.Find("GM").GetComponent<GameManager>().yellowPot;
			}
			item = (GameObject)Instantiate(item, transform.position, Quaternion.identity);
			item.transform.parent=(GameObject.Find("LEVEL_1").transform);

			hasItem=true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
