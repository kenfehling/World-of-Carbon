using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * This class should be attached to any object created dynamically on a level
 */
public class PlacementGridComponent : MonoBehaviour {

	private PlacementGrid grid = null;
	public PlacementGrid Grid {
		get {
			CreateGrid ();
			return grid;
		}
	}

	// These are for designer input to say which cells are filled
	public bool[] closedSpots;
	public int width, height;

	// Create internal grid if it hasn't been created yet
	private void CreateGrid() {
		if (grid == null) {
			grid = new PlacementGrid (width, height, closedSpots);
		}
	}
}
