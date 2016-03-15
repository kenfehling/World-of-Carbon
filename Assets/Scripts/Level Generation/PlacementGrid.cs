using UnityEngine;
using System.Collections;

/*
 * This class keeps track of a grid of cells that are "closed" or not
 */
public class PlacementGrid {

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
}
