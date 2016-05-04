using UnityEngine;
using System.Collections;

// Keeps track of the reactions in the game
public class Reaction : MonoBehaviour {

	public ArrayList reaction;
	public int playerReactant;
	public int gameMolecule;
	// Treat reaction as a stack for undoing functionality
	// Store reactants and then products
	// Map reactants to products using indicies
	// Have 2D array and look at x and y to get product
	// playerReactant = x
	// gameMolecule = y


	public void returnProduct(Molecule playerReactant, Molecule gameMolecule, Molecule [,] reactionTable){
		// go to the index of the two ints to get the product

		// return product
		//Molecule product = new Molecule();

	}
		
}
