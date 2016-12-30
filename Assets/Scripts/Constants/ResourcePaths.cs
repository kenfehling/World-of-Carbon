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
    private static string ParticleEffectsRoot = "Particle Effects/";
    private static string UIRoot = "UI/";
    private static string UIComponentsRoot = UIRoot + "Components/";
    private static string UIImagesRoot = UIComponentsRoot + "Images/";
    private static string UITHUDRoot = UIComponentsRoot + "THUD/";
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

    //UI Elements
    public static string DragLine = UIRoot + "Drag Line";

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
    public static string DiamondMol = MoleculesRoot + "Diamond1";

    //Effects
    public static string TransExplosion = ParticleEffectsRoot + "TransExplosion";

    //UI Elements

        //Player
        private static string PlayerTHUDRoot = UITHUDRoot + "Player/";
        public static string PlayerTHUDImage = PlayerTHUDRoot + "Player";
        public static string PlayerTHUDTitle = PlayerTHUDRoot + "PlayerTitle";
        public static string PlayerTHUDDescription = PlayerTHUDRoot + "PlayerDescription";

        //Red Molecule
        private static string RedMolTHUDRoot = UITHUDRoot + "RedMol/";
        public static string RedMolTHUDImage = RedMolTHUDRoot + "RedMol";
        public static string RedMolTHUDTitle = RedMolTHUDRoot + "RedMolTitle";
        public static string RedMolTHUDDescription = RedMolTHUDRoot + "RedMolDescription";

        //Blue Molecule
        private static string BlueMolTHUDRoot = UITHUDRoot + "BlueMol/";
        public static string BlueMolTHUDImage = BlueMolTHUDRoot + "BlueMol";
        public static string BlueMolTHUDTitle = BlueMolTHUDRoot + "BlueMolTitle";
        public static string BlueMolTHUDDescription = BlueMolTHUDRoot + "BlueMolDescription";

        //Yellow Molecule
        private static string YelMolTHUDRoot = UITHUDRoot + "YelMol/";
        public static string YelMolTHUDImage = YelMolTHUDRoot + "YelMol";
        public static string YelMolTHUDTitle = YelMolTHUDRoot + "YelMolTitle";
        public static string YelMolTHUDDescription = YelMolTHUDRoot + "YelMolDescription";

        //CO2
        private static string CO2THUDRoot = UITHUDRoot + "CO2/";
        public static string CO2THUDImage = CO2THUDRoot + "CO2";
        public static string CO2THUDTitle = CO2THUDRoot + "CO2Title";
        public static string CO2THUDDescription = CO2THUDRoot + "CO2Description";

        //CH4
        private static string CH4THUDRoot = UITHUDRoot + "CH4/";
        public static string CH4THUDImage = CH4THUDRoot + "CH4";
        public static string CH4THUDTitle = CH4THUDRoot + "CH4Title";
        public static string CH4THUDDescription = CH4THUDRoot + "CH4Description";

        //O2
        private static string OxideTHUDRoot = UITHUDRoot + "O2/";
        public static string OxideTHUDImage = OxideTHUDRoot + "O2";
        public static string OxideTHUDTitle = OxideTHUDRoot + "O2Title";
        public static string OxideTHUDDescription = OxideTHUDRoot + "O2Description";

        //H2O
        private static string H2OTHUDRoot = UITHUDRoot + "H2O/";
        public static string H2OTHUDImage = H2OTHUDRoot + "H2O";
        public static string H2OTHUDTitle = H2OTHUDRoot + "H2OTitle";
        public static string H2OTHUDDescription = H2OTHUDRoot + "H2ODescription";
        
        //SO
        private static string SOTHUDRoot = UITHUDRoot + "SO/";
        public static string SOTHUDImage = SOTHUDRoot + "SO";
        public static string SOTHUDTitle = SOTHUDRoot + "SOTitle";
        public static string SOTHUDDescription = SOTHUDRoot + "SODescription";

        //HPlus
        private static string HPlusTHUDRoot = UITHUDRoot + "H+/";
        public static string HPlusTHUDImage = HPlusTHUDRoot + "H+";
        public static string HPlusTHUDTitle = HPlusTHUDRoot + "H+Title";
        public static string HPlusTHUDDescription = HPlusTHUDRoot + "H+Description";

        //HCO3-
        private static string HCO3MinusTHUDRoot = UITHUDRoot + "HCO3-/";
        public static string HCO3MinusTHUDImage = HCO3MinusTHUDRoot + "HCO3-";
        public static string HCO3MinusTHUDTitle = HCO3MinusTHUDRoot + "HCO3-Title";
        public static string HCO3MinusTHUDDescription = HCO3MinusTHUDRoot + "HCO3-Description";

        //NO3Minus
        private static string NO3MinusTHUDRoot = UITHUDRoot + "NO3-/";
        public static string NO3MinusTHUDImage = NO3MinusTHUDRoot + "NO3-";
        public static string NO3MinusTHUDTitle = NO3MinusTHUDRoot + "NO3-Title";
        public static string NO3MinusTHUDDescription = NO3MinusTHUDRoot + "NO3-Description";

        //CAO
        private static string CAOTHUDRoot = UITHUDRoot + "CAO/";
        public static string CAOTHUDImage = CAOTHUDRoot + "CAO";
        public static string CAOTHUDTitle = CAOTHUDRoot + "CAOTitle";
        public static string CAOTHUDDescription = CAOTHUDRoot + "CAODescription";

        //Ca2Plus
        private static string Ca2PlusTHUDRoot = UITHUDRoot + "Ca2+/";
        public static string Ca2PlusTHUDImage = Ca2PlusTHUDRoot + "Ca2+";
        public static string Ca2PlusTHUDTitle = Ca2PlusTHUDRoot + "Ca2+Title";
        public static string Ca2PlusTHUDDescription = Ca2PlusTHUDRoot + "Ca2+Description";

        //Mg2Plus
        private static string Mg2PlusTHUDRoot = UITHUDRoot + "Mg2+/";
        public static string Mg2PlusTHUDImage = Mg2PlusTHUDRoot + "Mg2+";
        public static string Mg2PlusTHUDTitle = Mg2PlusTHUDRoot + "Mg2+Title";
        public static string Mg2PlusTHUDDescription = Mg2PlusTHUDRoot + "Mg2+Description";
}
