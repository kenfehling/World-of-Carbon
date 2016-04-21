using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	// Used to keep track of where we can place objects when generating a level
	private PlacementGrid levelPGrid;
	// Used to keep track of what spots actually have objects in them
	private PlacementGrid occupiedGrid;

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
		foreach(PGridCell cell in levelPGrid.Cells()) {
			if (CanPlaceObject(obstacleGrid, cell)) {
				availableSpots.Add(cell);
			}
		}
		// Then randomly pick one, place it, and recalculate grid
		if (availableSpots.Count > 0) {
			int spotToPlace = UnityEngine.Random.Range(0, availableSpots.Count);
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
		if (obstacleGrid.Height + cell.Row > levelPGrid.Height
			|| obstacleGrid.Width + cell.Col > levelPGrid.Width)
			return false;
		
		// Go through obstacle's placement grid and make sure that each spot
		// it needs is available, starting at cell
		for (int r = 0; r < obstacleGrid.Height; r++) {
			for (int c = 0; c < obstacleGrid.Width; c++) {
				// If a cell is closed on the obstacle then it is occupied
				// If a cell is closed on the main grid, it is occpupied or adjacent to an occupied spot
				if (obstacleGrid.Closed(r, c)
					&& levelPGrid.Closed(cell.Row + r, cell.Col + c)) {
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
				// remember that there is actually an obstacle at this cell
				occupiedGrid.SetCell (r + cell.Row, c + cell.Col, true);

				for (int i = r + cell.Row - 1; i <= r + cell.Row + 1; i++) {
					for (int j = c + cell.Col - 1; j <= c + cell.Col + 1; j++) {
						if (i >= 0 && i < levelPGrid.Height
							&& j >= 0 && j < levelPGrid.Width) {
							levelPGrid.SetCell (i, j, true);
							//GameManager.objects.Create (ResourcePaths.SpotMarker, new Vector3 (j+.5f, -i-.5f, 0), Quaternion.identity);
						}
					}
				}
			}
		}
	}

	// NOT FINISHED (is there a better way to do this?)
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

	/*
	 * Randomly place a molecule or one cell size object in the game world
	 * Params - molecule: the GameObject to place
	 */
	bool PlaceMoleculeRandomly(GameObject molecule) {
		
		// For now, assume that molecule takes up one cell

		// Find available spots to place molecule
		List<PGridCell> availableSpots = new List<PGridCell> ();
		foreach (PGridCell cell in occupiedGrid.Cells()) {
			if (!cell.Closed)
				availableSpots.Add (cell);
		}

		// Then randomly pick one, place it, and recalculate grid
		if (availableSpots.Count > 0) {
			int spotToPlace = UnityEngine.Random.Range(0, availableSpots.Count);
			molecule.transform.Translate(new Vector3 (availableSpots[spotToPlace].Col+.5f, -availableSpots[spotToPlace].Row-.5f, 0));
			occupiedGrid.SetCell (availableSpots [spotToPlace].Row, availableSpots [spotToPlace].Col, true);
			return true;
		}

		return false;
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
		// Get level parameters
		int levelWidth = 9, levelHeight = 5;
		int levelPressure = 600;
		int levelTemperature = 200;

		GameManager.state.SetInitialParams (levelWidth, levelHeight, levelPressure, levelTemperature);

		// Create grids for level generator
		bool[] gridSpots = new bool[levelWidth * levelHeight];
		Array.Clear (gridSpots, 0, gridSpots.Length);
		levelPGrid = new PlacementGrid (levelWidth, levelHeight, gridSpots);
		occupiedGrid = new PlacementGrid (levelWidth, levelHeight, gridSpots);

		// Place level border
		var border = GameManager.objects.Create(ResourcePaths.SampleBorder);
		PlaceObstacleAtLocation (border, 0, 0);

		// Place level obstacles
		string[] levelObstacles = { ResourcePaths.SampleObstacle, ResourcePaths.SmallSampleObstacle };
		int[] levelObstacleAmounts = { 1, 2 };

		for (int i = 0; i < levelObstacles.Length; i++) {
			for (int o = 0; o < levelObstacleAmounts [i]; o++) {
				var obstacle = GameManager.objects.Create (levelObstacles [i]);
				if (!PlaceObstacleRandomly (obstacle))
					obstacle.SetActive (false);
			}
		}

		// Place level molecules
		string[] levelMolecules = {ResourcePaths.OxygenMolecule, ResourcePaths.NitrogenMolecule};
		int[] levelMoleculeAmounts = { 2, 1 };

		for (int i = 0; i < levelMolecules.Length; i++) {
			for (int m = 0; m < levelMoleculeAmounts [i]; m++) {
				var molecule = GameManager.objects.Create (levelMolecules [i]);
				if (!PlaceMoleculeRandomly (molecule))
					molecule.SetActive (false);
			}
		}

		// Place player
		string playerMoleculeString = ResourcePaths.CarbonMolecule;
		var playerMolecule = GameManager.objects.Create (playerMoleculeString);
		var player = GameManager.objects.Create(ResourcePaths.Player);
		playerMolecule.transform.SetParent (player.transform);
		if (!PlaceMoleculeRandomly (player))
			player.SetActive (false);
	}

	public void SwitchLevel(string newLevelFilePath) {
		// Use ObjectManager to "destroy" all objects in the level

		// Then create the new level
		CreateLevel (newLevelFilePath);
	}
}
