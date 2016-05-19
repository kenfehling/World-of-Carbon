using UnityEngine;
using System.Collections.Generic;

/**
 * This class is used to handle creating and destroying objects to be used in the game world
 */
public class ObjectManager : MonoBehaviour {

	// keeps an object recylcing stack for each type of object needed for this level
	private Dictionary<string, Stack<GameObject>> stacks;

	public ObjectManager() {
		stacks = new Dictionary<string, Stack<GameObject>> ();
	}

	// Initializes a stack for each type in resources
	public void Initialize(List<string> resources) {
		// TODO: delete all entries in stacks that are not in resources

		// create a new stack for each resource, or reuse one if it existed previously
		foreach (string s in resources) {
			if (stacks.ContainsKey (s))
				//TODO: destroy each object on this stack
				stacks [s].Clear ();
			else
				stacks [s] = new Stack<GameObject> ();
		}
	}

	public GameObject Create(string obj) {
		return Create (obj, Vector3.zero, Quaternion.identity);
	}

	public GameObject Create(string obj, Vector3 position, Quaternion rotation) {
		// only can create objects already specified for this level
		if (!stacks.ContainsKey (obj)) {
			//return null;
			// for debugging, just create new stack
			stacks[obj] = new Stack<GameObject>();
		}

		if (stacks [obj].Count > 0) {
			var newObj = stacks [obj].Pop ();
			newObj.SetActive (true);
			return newObj;
		}
		else {
			// TODO: have each world object extend some WorldObject class or whatever to keep track of its relative path
			var prefab = Resources.Load (obj);
			var newObj = (GameObject)Instantiate (prefab, position, rotation);
			newObj.SetActive (true);
			return newObj;
		}
	}

	public void Destroy(GameObject obj) {
		// TODO: get path attribute from obj, probably from WorldObject class
		string path = "";
		// only can create objects already specified for this level
		if (!stacks.ContainsKey (path)) {
			//return;
			// for debugging, just create new stack
			stacks[path] = new Stack<GameObject>();
		}

		obj.SetActive (false);
		stacks [path].Push (obj);
	}
}
