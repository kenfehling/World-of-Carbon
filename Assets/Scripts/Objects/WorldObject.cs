using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {

	// a unique id assigned to this object
	private int objectID;
	public int ObjectID {
		get { return objectID; }
	}

	// the path to this object in the resources folder
	private string resourcePath;
	public string ResourcePath {
		get { return resourcePath; }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetID(int id) {
		objectID = id;
	}

	public void SetPath(string path) {
		resourcePath = path;
	}
}
