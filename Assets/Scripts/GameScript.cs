using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameScript : MonoBehaviour {
	//game thing

	public List<GameObject> spawnPoints;
	public GameObject cursor;
	public GameObject player;

	public GameObject activeItem;
	public GameObject item1;
	public GameObject item2;

    //game manager object
    private GameObject gm;



    //settin up timer
    public float totaltime = 80;
    private float timeleft;


    // Use this for initialization
    void Start () {


        //set up timer
        timeleft = totaltime;


        //bring in objects

        cursor = GameObject.Find ("cursor");
		player = GameObject.Find ("player");
        gm = GameObject.Find("GM");



        //set things at spawn points
        cursor.transform.position = player.transform.position;

		//loops to setup item spawn points
		spawnPoints= new List<GameObject>();
		int i = 0;
		while( GameObject.Find("itemSpawn_"+(i+1)) != null){
			//will add on to place certain items at certain types of spawn points
			spawnPoints.Add(GameObject.Find("itemSpawn_"+(i+1)));
			i++;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		//if clicking place mouse cursor thing
		if (Input.GetMouseButton(0) ) {
			Vector3 pos=Camera.main.ScreenToWorldPoint( Input.mousePosition );
			pos.z=0;
			cursor.transform.position = pos;
		}



        if (timeleft > 0)
        {
            timeleft = timeleft - Time.deltaTime;
        }
        else
        {
            GameObject[] names = GameObject.FindGameObjectsWithTag("pot");
            if (names.Length > 0)
            {
                foreach (GameObject item in names)
                {
                    Destroy(item);
                }
            }
            

        }


    }
}