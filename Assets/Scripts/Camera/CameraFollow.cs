using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        if (!player)
        {
            player = GameObject.Find("Player");
        }
    }

    void LateUpdate () {
		if (player != null) {
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
		}
	}    

	public void SetPlayer(ref PlayerManager p) {
		player = p.gameObject;
	}
}
