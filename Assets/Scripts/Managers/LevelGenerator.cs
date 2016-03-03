using UnityEngine;
using System.Collections;
using System;

public class LevelGenerator {

	/**
	 * This method places an obstacle in the game world.
	 * params - obstacle: the obstacle to place - PLACEHOLDER
	 * 			dynamic: if this obstacle should be dynamically placed
	 * 					(contrary, has static position to be placed at)
	 * returns - true if the object could be placed, false otherwise
	 */
	bool PlaceObstacle(GameObject obstacle, bool dynamic) {
		bool objectPlaced = false;
		/*
		 // In dynamic placement, find all cells where obstacle could be placed,
		 //  and then randomly pick one and instantiate it
		 if (dynamic) {
		 	 List<Cell> availableSpots;
			 foreach (cell in grid) {
				 if (CanPlaceObject(object, cell) {
					availableSpots.add(cell);
				 }
			 }
			 if (availableSpots.Count > 0) {
				int spotToPlace = rand(0, availableSpots.Count);
				GameManager.objects.Create(object.path, new Vector2(availableSpots[spotToPlace].x, availableSpots[spotToPlace].y), Quaternion.identity);
				CalculateAvailableCells(obstacle, availableSpots[spotToPlace]);
				objectPlaced = true;
			 }
			 else
			 	objectPlaced = false;
		 }
		 else {
			 GameManager.objects.Create(object.path, new Vector2(obstacle.defaultcell.x, obstacle.defaultcell.y), Quaternion.identity);
			 CalculateAvailableCells(obstacle, obstacle.defaultcell);
			 objectPlaced = true;
		 }
		 */
		return objectPlaced;
	}

	/*
	 * This method returns if the obstacle can be placed at the cell in the gameworld
	 * Params - obstacle: the obstacle to place - PLACEHOLDER
	 * 			cell: the cell to test placement on - PLACEHOLDER
	 */
	bool CanPlaceObject(GameObject obstacle, int cell) {
		/*
		 // Go through obstacle's placement grid and make sure that each spot
		 // it needs is available, starting at cell
		 for (int r = 0; r < obstacle.grid.height; r++) {
			for (int c = 0; c < obstacle.grid.width; c++) {
				if (obstacle.grid.NeedsSpace(r, c)
					&& !grid.cells[cell.r + r][cell.c + c].available) {
					return false;
				}
			}
		 }
		 */
		return true;
	}

	/*
	 * This method calculates the new spots that are no longer available after object placement
	 * Params - obstacle: the obstacle placed - PLACEHOLDER
	 * 			cell: the cell the obstacle was placed on - PLACEHOLDER
	 */
	void CalculateAvailableCells(GameObject obstacle, int cell) {
		/*
		 */
	}

	/**
	 * This method is called whenever you are loading a new level
	 * It handles creating the world of the level
	 * Should it handle other duties called at load time? (give/take player control, loading transitions, etc.)
	 */
	public void CreateLevel(string levelFilePath, Action onLoad) {
		
		// Open levelFile
			// Different attributes of levelFile:
			// - All artwork needed
			// - All different elements/objects needed
			// - Rules for how objects should be generated
			// - Initial game state parameters


		// Use ObjectManager to create necessary objects for the level

		// Call load callback function
		onLoad();
	}

	/**
	 * Just testing out using this class before we have level loading implemented
	 */
	public void CreateSampleLevel() {
		// Use ObjectManager to create necessary objects for the level
		GameManager.state.SetInitialParams (800, 600, 600, 200);

		GameManager.objects.Create(ResourcePaths.SampleObstacle, Vector3.zero, Quaternion.identity);
	}

	public void SwitchLevel(string newLevelFilePath, Action onLoad) {
		// Use ObjectManager to "destroy" all objects in the level

		// Then create the new level
		CreateLevel (newLevelFilePath, onLoad);
	}
}
