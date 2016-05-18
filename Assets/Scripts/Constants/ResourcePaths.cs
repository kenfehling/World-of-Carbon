using UnityEngine;
using System.Collections;

/**
 * This class is used to reference path names for resources in the resources folder (gameworld objects, art, etc.)
 * Basically for anything that needs to be dynamically loaded
 */
public class ResourcePaths {

	public static string ArtRoot = "Art/";
	private static string WorldObjectsRoot = "World Objects/";
	private static string MoleculesRoot = "Molecules/";

	public static string Player = "Player";

	// Obstacles
	public static string SampleMolecule = WorldObjectsRoot + "Sample Molecule";
	public static string SampleObstacle = WorldObjectsRoot + "Sample Obstacle Group";
	public static string SmallSampleObstacle = WorldObjectsRoot + "Small Sample Obstacle";
	public static string SampleBorder = WorldObjectsRoot + "Sample Game Border";
	public static string SpotMarker = WorldObjectsRoot + "Spot Marker";

	// Molecules
	public static string CarbonMolecule = MoleculesRoot + "Carbon";
	public static string OxygenMolecule = MoleculesRoot + "Oxygen";
	public static string NitrogenMolecule = MoleculesRoot + "Nitrogen";
}
