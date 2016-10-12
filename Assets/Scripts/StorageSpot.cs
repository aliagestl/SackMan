using UnityEngine;
using System.Collections;

public class StorageSpot : MonoBehaviour {

	GameScript level;
	GameManager gm;
	
	public GameObject itemPrefab;
	public GameObject item;
	public string itemType;

	public bool isMouseOver=false;


	// Use this for initialization
	void Start () {
		level = GameObject.Find("LEVEL_1").GetComponent<GameScript>();
		gm = GameObject.Find("GM").GetComponent<GameManager>();
		itemType = itemPrefab.name;
		
		item = (GameObject)Instantiate(itemPrefab, transform.position, Quaternion.identity);
		item.transform.parent=(this.gameObject.transform);
		item.SetActive (false);

	}

	void OnMouseEnter(){
		isMouseOver = true;
	}
	void OnMouseExit(){
		isMouseOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActiveAndEnabled) {
			
			//interact with point
			if (Input.GetMouseButtonDown(0)&& isMouseOver ) {
				Debug.Log("clicked on item storage");

				level.player.SendMessage ("getPot", this.gameObject);
				Debug.Log ("asking player to place item");

			}
		}
	}
}
