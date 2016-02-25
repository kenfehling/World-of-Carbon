using UnityEngine;
using System.Collections.Generic;

/**
 * This class is used to handle creating and destroying objects to be used in the game world
 */
public class ObjectManager : MonoBehaviour {



	// Let's redo how this class works slightly
	// Instead of this paradigm, the stacks will be dynamically generated based on the prefabs we want to load
	// Designers will need to make specific prefabs for each object (for collision boxes, art, whatever)






	//TODO: Have base object for each object type that will serve as folder
	//		This will make it easier to return objects to their proper recycling stacks
	//		Should replace specific destroy methods with one general one that uses this


	// Each of these public GameObjects will be assigned a prefab base model
	//  for the type of object they represent
	public GameObject reactionObjectModel;
	public GameObject obstacleModel;
	public GameObject particleModel;
	public GameObject terrainModel;

	// Each of these Stacks will hold onto objects that have been "Destroyed"
	//  so we can reuse them when needed
	private Stack<GameObject> reactionObjectStack;
	private Stack<GameObject> obstacleStack;
	private Stack<GameObject> particleStack;
	private Stack<GameObject> terrainStack;

	// Called at initialization
	void Start () {
		// Create Stacks, which will handle recycling of game world objects
		reactionObjectStack = new Stack<GameObject>();
		obstacleStack = new Stack<GameObject>();
		particleStack = new Stack<GameObject>();
		terrainStack = new Stack<GameObject>();
	}

	public GameObject CreateReactionObject(Vector3 t, Quaternion q) {
		GameObject newObj;
		if (reactionObjectStack.Count == 0) {
			newObj = (GameObject)Instantiate (reactionObjectModel, t, q);
		} else {
			newObj = reactionObjectStack.Pop ();
			newObj.transform.position = t;
			newObj.transform.rotation = q;
		}
		newObj.SetActive (true);
		return newObj;
	}

	public GameObject CreateObstacle(Vector3 t, Quaternion q) {
		GameObject newObj;
		if (obstacleStack.Count == 0) {
			newObj = (GameObject)Instantiate (obstacleModel, t, q);
		} else {
			newObj = obstacleStack.Pop ();
			newObj.transform.position = t;
			newObj.transform.rotation = q;
		}
		newObj.SetActive (true);
		return newObj;
	}

	public GameObject CreateParticle(Vector3 t, Quaternion q) {
		GameObject newObj;
		if (particleStack.Count == 0) {
			newObj = (GameObject)Instantiate (particleModel, t, q);
		} else {
			newObj = particleStack.Pop ();
			newObj.transform.position = t;
			newObj.transform.rotation = q;
		}
		newObj.SetActive (true);
		return newObj;
	}

	public GameObject CreateTerrain(Vector3 t, Quaternion q) {
		GameObject newObj;
		if (terrainStack.Count == 0) {
			newObj = (GameObject)Instantiate (terrainModel, t, q);
		} else {
			newObj = terrainStack.Pop ();
			newObj.transform.position = t;
			newObj.transform.rotation = q;
		}
		newObj.SetActive (true);
		return newObj;
	}

	public void DestroyReactionObject(GameObject reactionObject) {
		// TODO: Reset object so it has default properties
		reactionObject.SetActive(false);
		reactionObjectStack.Push(reactionObject);
	}

	public void DestroyObstacle(GameObject obstacle) {
		// TODO: Reset object so it has default properties
		obstacle.SetActive(false);
		obstacleStack.Push(obstacle);
	}

	public void DestroyParticle(GameObject particle) {
		// TODO: Reset object so it has default properties
		particle.SetActive(false);
		particleStack.Push(particle);
	}

	public void DestroyTerrain(GameObject terrain) {
		// TODO: Reset object so it has default properties
		terrain.SetActive(false);
		terrainStack.Push(terrain);
	}
}
