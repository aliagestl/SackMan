using UnityEngine;
using System.Collections;

public class ItemPoint : MonoBehaviour {

	GameScript level;
	GameManager gm;

	public GameObject itemPrefab;
	public GameObject item;
	public string itemType;
	public bool hasItem;

	public bool startWithItem;
	public bool isMouseOver=false;


	// Use this for initialization
	void Start () {
		level = GameObject.Find("LEVEL_1").GetComponent<GameScript>();
		gm = GameObject.Find("GM").GetComponent<GameManager>();
		itemType = itemPrefab.name;

		item = (GameObject)Instantiate(itemPrefab, transform.position, Quaternion.identity);
		item.transform.parent=(this.gameObject.transform);
		item.SetActive (false);

		//setup spawn point items
		if (startWithItem) {
			ShowItem();
		} else {
			HideItem();
		}
	}

	void OnMouseEnter(){
		isMouseOver = true;
	}
	void OnMouseExit(){
		isMouseOver = false;
	}

	//old version of additem--not using this
//	public void AddItem(string itemType){
//		if (hasItem==false) {
//			if (itemType == "redPot") {
//				item=GameObject.Find("GM").GetComponent<GameManager>().redPot;
//			} else if (itemType == "yellowPot") {
//				item=GameObject.Find("GM").GetComponent<GameManager>().yellowPot;
//			}
//			item = (GameObject)Instantiate(item, transform.position, Quaternion.identity);
//			item.transform.parent=(this.gameObject.transform);
//
//			hasItem=true;
//		}
//	}

	//'add' and 'remove' the item
	public void ShowItem(){
		item.SetActive (true);
		hasItem = true;
	}
	public void HideItem(){
		item.SetActive(false);
		hasItem = false;
	}

	// Update is called once per frame
	void Update () {

		if (gm.timeLeft <= 0) {
			HideItem();
		}

		if (isActiveAndEnabled) {

			//interact with point
			if (Input.GetMouseButtonDown(0)&& isMouseOver ) {
				Debug.Log("clicked on item point");
				if (!hasItem) {
					level.player.SendMessage ("interactWithPoint", this.gameObject);
					Debug.Log ("asking player to place item");
				} else {
					level.player.SendMessage ("interactWithPoint", this.gameObject);
					Debug.Log("asking player to take item");
				}
			}
		}

	}
}
