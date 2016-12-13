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
	public Dictionary<string, string> table = new Dictionary<string,string>();

    void Start()
    {
        //Setup the table!
        //The way this works is that collisions between molecules concatenate the MoleculeIDs, and that
        //is mapped to a product in the reaction table.

    
    }
}
