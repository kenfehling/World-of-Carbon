using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    GameObject player;

    void LateUpdate () {
		if (player != null) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
		}
	}    

	public void SetPlayer(ref GameObject p) {
		player = p;
	}
}
