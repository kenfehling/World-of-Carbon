using UnityEngine;
using System.Collections;

/**
 * This class represents a single cell in a placement grid
 */
public class PGridCell {

	// Row and column relative to grid
	private int r, c;
	// If this cell is "closed"
	private bool closed;

	public int Row {
		get { return r; }
	}

	public int Col {
		get { return c; }
	}

	public bool Closed {
		get { return closed; }
		set { closed = value; }
	}

	public PGridCell(int row, int column, bool closed) {
		r = row;
		c = column;
		this.closed = closed;
	}
}
