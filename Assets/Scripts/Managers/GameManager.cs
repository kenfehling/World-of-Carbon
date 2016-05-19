using UnityEngine;
using System.Collections;

/*
 * This is the launching point for the application and should be attached to a game manager world object.
 * You access the necessary game objects statically from here.
 * 
 * author: Alex Scarlatos
 * February 2016
 */
public class GameManager : MonoBehaviour {

	public static GameState state;
	public static GUIManager gui;
	public static SoundManager sound;
	public static ObjectManager objects;
	public static LevelGenerator levels;
	public static ArtManager art;
	public static ReactionTable reactionTable;

	// Will be set in game world before everything is run
	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
		// Instantiate internal managers

		// Should I instantiate them this way?
		// Or with game objects?
		// Or with prefabs?
		state = new GameState();
		gui = new GUIManager();
		sound = new SoundManager();
		objects = new ObjectManager();
		levels = new LevelGenerator();
		reactionTable = new ReactionTable();

		// Start first level
		state.SetLoading(true);
		//levels.CreateLevel("firstLevel.xml", ShowLevel);
		levels.CreateSampleLevel();

		// Set the camera to follow the game's player
		mainCamera.GetComponent<CameraFollow> ().SetPlayer (ref state.player);
	}

	// where should this functionality really go?
	void ShowLevel() {
		state.SetLoading (false);
		// art . transition from loading to world view
		// give player control?

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
