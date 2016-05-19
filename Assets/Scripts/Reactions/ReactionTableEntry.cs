using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class holds information about the reaction of two molecules, to be stored in the reaction table
 */
public class ReactionTableEntry {

	// The products created by the reaction if there is one
	public string[] products;

	public ReactionTableEntry(string[] products) {
		this.products = products;
	}
}
