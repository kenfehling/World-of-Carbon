using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class holds information about the reaction of two molecules, to be stored in the reaction table
 */
public class ReactionTableEntry {
    public enum Move {up, down, none};
    public enum Temperature {lo, med, hi};
    public enum Pressure {lo, med, hi};

    // The products created by the reaction if there is one
    public string[] products;
    public Move move;
    public Temperature temperature;
    public Pressure pressure;

	public ReactionTableEntry(string[] products, Move move, Temperature temperature, Pressure pressure) {
		this.products = products;
        this.move = move;
        this.temperature = temperature;
        this.pressure = pressure;
	}
}
