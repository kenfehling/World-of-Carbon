using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class serves as a lookup for what reaction is to occur when two molecules collide.
 * 
 * author: Alex Scarlatos
 * May 2016
 */
public class ReactionTable {

	// Map of molecule name to index in table
	Dictionary<string, int> moleculeIndices;
	// The lookup table for reactions
	ReactionTableEntry[][] table;

	public ReactionTable() {
		moleculeIndices = new Dictionary<string, int> ();
	}

	// Build square table, where each row and column has all molecules for the level
	public void SetUpTable(string[] allMolecules) {
		table = new ReactionTableEntry[allMolecules.Length][];
		for (int i = 0; i < allMolecules.Length; i++) {
			moleculeIndices.Add (allMolecules [i], i);
			table[i] = new ReactionTableEntry[allMolecules.Length];
			for (int x = 0; x < allMolecules.Length; x++) {
				table [i] [x] = null;
			}
		}
	}

	// Define a reaction, where two molecules react to create an array of products
	public void RegisterReaction(string molecule1, string molecule2, ReactionTableEntry entry) {
		table [moleculeIndices [molecule1]] [moleculeIndices [molecule2]] = entry;
	}

	// Get the reaction info for a pair of molecules
	public ReactionTableEntry GetReaction(string molecule1, string molecule2) {
		return table [moleculeIndices [molecule1]] [moleculeIndices [molecule2]];
	}
}
