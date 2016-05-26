using UnityEngine;
using System.Collections;

/**
 * This class keeps track of gameplay variables and overall game state.
 * 
 * author: Alex Scarlatos
 * February 2016
 */
public class GameState {

	private bool loading;

	public GameObject player = null;

	// Sets the reference to the player, must be called when player is created by level generator
	public void SetPlayer(ref GameObject p) {
		player = p;
	}

	public bool Loading() {
		return loading;
	}

	public void SetLoading(bool state) {
		loading = state;
	}
}
