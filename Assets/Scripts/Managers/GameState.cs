using UnityEngine;
using System.Collections;

/**
 * This class keeps track of gameplay variables and overall game state
 * 
 * TODO: Should it also handle high level control functions like switching levels?
 * 
 */
public class GameState : MonoBehaviour {

	private bool loading;

	private int pressure;
	private int temperature;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool Loading() {
		return loading;
	}

	public void SetLoading(bool state) {
		loading = state;
	}

	public int Pressure() {
		return pressure;
	}

	public int Temperature() {
		return temperature;
	}
}
