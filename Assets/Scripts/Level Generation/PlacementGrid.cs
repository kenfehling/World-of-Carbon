using UnityEngine;
using System.Collections;

/*
 * This class keeps track of a grid of cells that are "closed" or not
 */
public class PlacementGrid {

	private int rotation;
	public int Rotation {
		get { return rotation; }
	}

	private int width;
	public int Width {
		get { return width; }
	}

	private int height;
	public int Height {
		get { return height; }
	}

	// Internal array of grid cells
	private PGridCell[] internalCells = null;

	public PlacementGrid(int width, int height, bool[] closedSpots) {
		// Make sure inital parameters make sense
		if (width * height != closedSpots.Length) {
			throw new UnityException ("Invalid size of array given width and height.");
		}
		this.rotation = 0;
		this.width = width;
		this.height = height;
		// Create internal array
		internalCells = new PGridCell[closedSpots.Length];
		for (int i = 0; i < closedSpots.Length; i++) {
			internalCells [i] = new PGridCell (i / width, i % width, closedSpots [i]);
		}
	}

	private int CellIndex(int r, int c) {
		return r * width + c;
	}

	public PGridCell[] Cells() {
		return internalCells;
	}

	public bool Closed(int r, int c) {
		if (r >= 0 && r < height && c >= 0 && c < width)
			return internalCells [CellIndex(r,c)].Closed;
		throw new UnityException ("Cell access out of range.");
	}

	public void SetCell(int r, int c, bool closed) {
		if (r >= 0 && r < height && c >= 0 && c < width)
			internalCells [CellIndex (r, c)].Closed = closed;
		else
			throw new UnityException ("Cell access out of range.");
	}

	// Rotate this grid left, recalculate internalCells and swap width and height
	public void RotateLeft() {
		PGridCell[] newInternalCells = new PGridCell[width * height];
		for (int i = 0; i < internalCells.Length; i++) {
			// new index is [numCols - 1 - col][row]
			int newRow = (width - 1) - (i % width);
			int newCol = i / width;
			int index = height * newRow + newCol;
			newInternalCells [index] = new PGridCell (newRow, newCol, internalCells [i].Closed);
		}

		internalCells = newInternalCells;
		int newHeight = width;
		width = height;
		height = newHeight;

		rotation = (rotation + 90) % 360;
	}
}
