using UnityEngine;
using System.Collections;
using System;

public class LevelGenerator : MonoBehaviour {

	//TODO: To keep track of all objects generated:
	//		 create base object that will parent the terrains
	//		 and the terrain will parent the other objects

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * This method is called whenever you are loading a new level
	 * It handles creating the world of the level
	 * Should it handle other duties called at load time? (give/take player control, loading transitions, etc.)
	 */
	public void CreateLevel(string levelFilePath, Action onLoad) {
		
		// Open levelFile
			// Different attributes of levelFile:
			// - All artwork needed
			// - All different elements/objects needed
			// - Rules for how objects should be generated

		// Use ObjectManager to create necessary objects for the level

		// Call load callback function
		onLoad();
	}

	/**
	 * Just testing out using this class before we have level loading implemented
	 */
	public void CreateSampleLevel() {
		// Use ObjectManager to create necessary objects for the level
		GameManager.objects.CreateTerrain(new Vector3(0,0,0), Quaternion.identity);

		GameManager.objects.CreateObstacle(new Vector3(0,0,0), Quaternion.identity);
		GameManager.objects.CreateObstacle(new Vector3(0,0,0), Quaternion.identity);
		GameManager.objects.CreateObstacle(new Vector3(0,0,0), Quaternion.identity);

		GameManager.objects.CreateReactionObject(new Vector3(0,0,0), Quaternion.identity);
		GameManager.objects.CreateReactionObject(new Vector3(0,0,0), Quaternion.identity);
		GameManager.objects.CreateReactionObject(new Vector3(0,0,0), Quaternion.identity);
		GameManager.objects.CreateReactionObject(new Vector3(0,0,0), Quaternion.identity);
		GameManager.objects.CreateReactionObject(new Vector3(0,0,0), Quaternion.identity);
	}

	public void SwitchLevel(string newLevelFilePath, Action onLoad) {
		// Use ObjectManager to "destroy" all objects in the level

		// Then create the new level
		CreateLevel (newLevelFilePath, onLoad);
	}
}
