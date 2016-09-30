using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	//gamestufffff
	enum GameStates {start, levelSelect , play,pause , end};
	GameStates GameState = GameStates.start;

	//i did a thing on gittttt

	//game state empty objects
	GameObject startScreen;
	GameObject gameScreen;
	GameObject endScreen;
	public List<GameObject> levels;

	public GameObject redPot;
	public GameObject yellowPot;
	public GameScript level;
	public string currentLevel= "LEVEL_1";//hardcoded

	// Use this for initialization
	void Start () {
		//setup game states
		startScreen = GameObject.Find("STARTSCREEN");
		endScreen = GameObject.Find("ENDSCREEN");

		//for now only use level 1
		gameScreen = GameObject.Find("LEVEL_1");
		level = GameObject.Find("LEVEL_1").GetComponent<GameScript>();

		//setup active state for stages
		startScreen.SetActive(true);
		gameScreen.SetActive(false);
		endScreen.SetActive(false);

	}

	//change/set current level
	void setLevel(string levelName){
		for (int i=0; i<levels.Count; i++) {
			if(levels[i].name==levelName){
				levels[i].SetActive(true);

				gameScreen = GameObject.Find(levelName);
				level = GameObject.Find(levelName).GetComponent<GameScript>();
			}
			else{
				levels[i].SetActive(false);
			}
		}
	}

	// Update is called once per frame
	void Update () {

		//check game states
		if (GameState == GameStates.start) {

			//change gamestate when clicked
			//evenutally will have to click on button to start
			if (Input.GetMouseButtonDown(0) ) {
				//turn off start screen
				startScreen.SetActive(false);
				//setup and load game
				gameScreen.SetActive(true);
				//wil add delay and button animation before switching states
				GameState = GameStates.play;
			}

//			//go directly to game
//			//turn off start screen
//			startScreen.SetActive(false);
//			//setup and load game
//			gameScreen.SetActive(true);
//			//wil add delay and button animation before switching states
//			GameState = GameStates.play;


		}
		else if(GameState == GameStates.play){

			//end game with escape
			if (Input.GetKeyDown(KeyCode.Return) ) {
				//turn off game screen
				gameScreen.SetActive(false);
				endScreen.SetActive(true);
				//wil add delay and button animation before switching states
				GameState = GameStates.end;
			}
		}
		else if(GameState==GameStates.end){

		}

		//close program with enter
		if (Input.GetKeyDown(KeyCode.Escape) ) {
			//quit game
			Quit();
		}
	}


	public void Quit()
	{
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
		#endif
		
		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
