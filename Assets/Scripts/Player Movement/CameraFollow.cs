using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
		}
	}

	public void SetPlayer(ref GameObject p) {
		player = p;
	}
}
