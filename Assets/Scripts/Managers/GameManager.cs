using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameState state;
	public static GUIManager gui;
	public static SoundManager sound;
	public static ObjectManager objects;
	public static LevelGenerator levels;
	public static ArtManager art;

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

		// Start first level
		state.SetLoading(true);
		//levels.CreateLevel("firstLevel.xml", ShowLevel);
		levels.CreateSampleLevel();
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
