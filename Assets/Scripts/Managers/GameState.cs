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

	// world pressure in torr
	private int pressure;
	// wordl temperature in Kelvin
	private int temperature;

	private int worldWidth;
	private int worldHeight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// called on level load to set the initial parameters for this level
	public void SetInitialParams(int width, int height, int initialPressure, int initialTemp) {
		worldWidth = width;
		worldHeight = height;
		pressure = initialPressure;
		temperature = initialTemp;
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

	public int WorldWidth() {
		return worldWidth;
	}

	public int WorldHeight() {
		return worldHeight;
	}
}
