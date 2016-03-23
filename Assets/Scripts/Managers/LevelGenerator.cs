using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	// Used to keep track of where we can place objects when generating a level
	private PlacementGrid grid;

	/**
	 * This method places an obstacle at the given cell location in the game world.
	 * params - obstacle: the obstacle to place
	 * 			r, c: the row, column pair of the cell to place the object at
	 * returns - true if the object could be placed, false otherwise
	 */
	bool PlaceObstacleAtLocation(GameObject obstacle, int r, int c) {
		obstacle.transform.Translate(new Vector3(c, -r, 0));
		PlacementGrid obstacleGrid = obstacle.GetComponent<PlacementGridComponent> ().Grid;
		CalculateAvailableCells (obstacleGrid, r, c);
		return true;
	}

	/**
	 * This method places an obstacle randomly somewhere in the game world.
	 * params - obstacle: the obstacle to place
	 * returns - true if the object could be placed, false otherwise
	 */
	bool PlaceObstacleRandomly(GameObject obstacle) {
		// Find all cells where obstacle could be placed
		List<PGridCell> availableSpots = new List<PGridCell> ();
		PlacementGrid obstacleGrid = obstacle.GetComponent<PlacementGridComponent> ().Grid;
		foreach(PGridCell cell in grid.Cells()) {
			if (CanPlaceObject(obstacleGrid, cell)) {
				availableSpots.Add(cell);
			}
		}
		// Then randomly pick one, place it, and recalculate grid
		if (availableSpots.Count > 0) {
			int spotToPlace = UnityEngine.Random.Range(0, availableSpots.Count);
			Debug.Log ("Spot: " + spotToPlace);
			obstacle.transform.Translate(new Vector3 (availableSpots[spotToPlace].Col, -availableSpots[spotToPlace].Row, 0));
			CalculateAvailableCells(obstacleGrid, availableSpots[spotToPlace].Row, availableSpots[spotToPlace].Col);
			return true;
		}
		Debug.Log ("No spots");
		return false;
	}

	/*
	 * This method returns if the obstacle can be placed at the given cell in the gameworld.
	 * Params - obstacleGrid: the PlacementGrid of the obstacle you are testing
	 * 			cell: the cell to test placement on
	 */
	bool CanPlaceObject(PlacementGrid obstacleGrid, PGridCell cell) {
		// False if grid bounding box goes outside bounds of level
		if (obstacleGrid.Height + cell.Row > grid.Height
		    || obstacleGrid.Width + cell.Col > grid.Width)
			return false;
		
		// Go through obstacle's placement grid and make sure that each spot
		// it needs is available, starting at cell
		for (int r = 0; r < obstacleGrid.Height; r++) {
			for (int c = 0; c < obstacleGrid.Width; c++) {
				// If a cell is closed on the obstacle then it is occupied
				// If a cell is closed on the main grid, it is occpupied or adjacent to an occupied spot
				if (obstacleGrid.Closed(r, c)
					&& grid.Closed(cell.Row + r, cell.Col + c)) {
					return false;
				}
			}
		 }
		return true;
	}

	/*
	 * This method calculates the new spots that are no longer available after object placement
	 * Params - obstacleGrid: the PlacementGrid for the obstacle just placed
	 * 			r, c: the row and column the obstacle was placed
	 */
	void CalculateAvailableCells(PlacementGrid obstacleGrid, int r, int c) {
		// Every cell around a closed cell in obstacleGrid is no longer available
		foreach(PGridCell cell in obstacleGrid.Cells()) {
			if (cell.Closed) {
				for (int i = r + cell.Row - 1; i <= r + cell.Row + 1; i++) {
					for (int j = c + cell.Col - 1; j <= c + cell.Col + 1; j++) {
						if (i >= 0 && i < grid.Height
						    && j >= 0 && j < grid.Width) {
							grid.SetCell (i, j, true);
							GameManager.objects.Create (ResourcePaths.SpotMarker, new Vector3 (j+.5f, -i-.5f, 0), Quaternion.identity);
						}
					}
				}
			}
		}
	}

	void RotateObjectLeft(GameObject obj) {
		PlacementGrid objGrid = obj.GetComponent<PlacementGridComponent> ().Grid;
		objGrid.RotateLeft ();	// rotate the grid
		obj.transform.Rotate (new Vector3 (0, 0, 90));	// rotate the transform
		// move to keep top of grid in upper left
		switch (objGrid.Rotation) {
			case 90:
				obj.transform.Translate(new Vector3(-objGrid.Height, 0, 0));
					break;
			case 180:
				//obj.transform.Translate(new Vector3(-objGrid.Width, objGrid.Height-objGrid.Width, 0));
					break;
			case 270:
				obj.transform.Translate (new Vector3 (-objGrid.Width, objGrid.Height-objGrid.Width, 0));
					break;
			case 0:
				obj.transform.Translate (new Vector3 (-objGrid.Height, 0, 0));
					break;
		}
	}

	/**
	 * This method is called whenever you are loading a new level
	 * It handles creating the world of the level
	 * Should it handle other duties called at load time? (give/take player control, loading transitions, etc.)
	 */
	public void CreateLevel(string levelFilePath) {
		
		// Open levelFile
			// Different attributes of levelFile:
			// - All artwork needed
			// - All different elements/objects needed
			// - Rules for how objects should be generated
			// - Initial game state parameters


		// Use ObjectManager to create necessary objects for the level
	}

	/**
	 * Just testing out using this class before we have level loading implemented
	 */
	public void CreateSampleLevel() {
		// Use ObjectManager to create necessary objects for the level
		int levelWidth = 9, levelHeight = 5;
		int levelPressure = 600;
		int levelTemperature = 200;

		GameManager.state.SetInitialParams (levelWidth, levelHeight, levelPressure, levelTemperature);

		bool[] gridSpots = new bool[levelWidth * levelHeight];
		Array.Clear (gridSpots, 0, gridSpots.Length);
		grid = new PlacementGrid (levelWidth, levelHeight, gridSpots);

		var border = GameManager.objects.Create(ResourcePaths.SampleBorder, Vector3.zero, Quaternion.identity);
		PlaceObstacleAtLocation (border, 0, 0);
		Debug.Log ("placed border");

		var obstacle = GameManager.objects.Create(ResourcePaths.SampleObstacle, Vector3.zero, Quaternion.identity);
		//RotateObjectLeft (obstacle);
		//RotateObjectLeft (obstacle);

		if (!PlaceObstacleRandomly (obstacle))
			obstacle.SetActive (false);
		obstacle = GameManager.objects.Create(ResourcePaths.SmallSampleObstacle, Vector3.zero, Quaternion.identity);
		if (!PlaceObstacleRandomly (obstacle))
			obstacle.SetActive (false);
		obstacle = GameManager.objects.Create(ResourcePaths.SmallSampleObstacle, Vector3.zero, Quaternion.identity);
		if (!PlaceObstacleRandomly (obstacle))
			obstacle.SetActive (false);
	}

	public void SwitchLevel(string newLevelFilePath) {
		// Use ObjectManager to "destroy" all objects in the level

		// Then create the new level
		CreateLevel (newLevelFilePath);
	}
}
