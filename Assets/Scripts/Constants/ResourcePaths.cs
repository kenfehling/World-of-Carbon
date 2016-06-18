using UnityEngine;
using System.Collections;

/**
 * This class is used to reference path names for resources in the resources folder (gameworld objects, art, etc.)
 * Basically for anything that needs to be dynamically loaded
 */
public class ResourcePaths {

	public static string ArtRoot = "Art/";
	private static string WorldObjectsRoot = "World Objects/Old";
	private static string MoleculesRoot = "Molecules/";
    private static string MiscRoot = "Misc/";

    //Audio roots
    private static string AudioRoot = "Audio/";
    private static string MusicRoot = AudioRoot + "Music/";
    private static string SoundsRoot = AudioRoot + "Sounds/";

    //Music
    public static string song1 = MusicRoot + "magma 1 temp";
    public static string song2 = MusicRoot + "magma 2 temp";
    public static string song3 = MusicRoot + "magma 3 temp";
    public static string musicManager = MusicRoot + "MusicManager";

    //Sound effects
    public static string clack1 = SoundsRoot + "Clack1";
    public static string clack2 = SoundsRoot + "Clack2";
    public static string clack3 = SoundsRoot + "Clack3";
    public static string clack4 = SoundsRoot + "Clack4";
    public static string levelUp = SoundsRoot + "levelDown";
    public static string levelDown = SoundsRoot + "levelUp";
    public static string soundManager = SoundsRoot + "SoundManager";

    //Player
    public static string Player = "Player";

	// Obstacles
	public static string SampleMolecule = WorldObjectsRoot + "Sample Molecule";
	public static string SampleObstacle = WorldObjectsRoot + "Sample Obstacle Group";
	public static string SmallSampleObstacle = WorldObjectsRoot + "Small Sample Obstacle";
	public static string SampleBorder = WorldObjectsRoot + "Sample Game Border";
	public static string SpotMarker = WorldObjectsRoot + "Spot Marker";

	// Molecules
	public static string CarbonMolecule = MoleculesRoot + "C";
	public static string OxygenMolecule = MoleculesRoot + "O2";
	public static string NitrogenMolecule = MoleculesRoot + "N2";
	public static string CarbonDioxideMolecule = MoleculesRoot + "CO2";
    public static string FreeCarbonMolecule = MoleculesRoot + "Free Carbon";

    //Effects
    public static string transExplosion = MiscRoot + "TransExplosion";
}
