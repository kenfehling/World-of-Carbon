using UnityEngine;
using System.Collections;

/**
 * This class is used to reference path names for resources in the resources folder (gameworld objects, art, etc.)
 * Basically for anything that needs to be dynamically loaded
 */
public class Resources : MonoBehaviour {

	public static string ArtRoot = "Art/";
	public static string WorldObjectsRoot = "World Objects/";
	public static string MoleculesRoot = "Molecules/";

	public static string SampleMolecule = WorldObjectsRoot + "Sample Molecule";

}
