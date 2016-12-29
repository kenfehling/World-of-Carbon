using UnityEngine;
using System.Collections;

/*
 * This is the launching point for the application and should be attached to a game manager world object.
 * You access the necessary game objects statically from here.
 * 
 * author: Alex Scarlatos
 * February 2016
 */
public class GameManager : MonoBehaviour {

	public static GUIManager gui;
    public static MusicManager music;
	public static SoundManager sound;
	public static ObjectManager objects;
	public static LevelGenerator levels;
	public static LayerManager art;
	public static ReactionTable reactionTable;
    public static WorldProperties worldProperties;
    public static GameState state;
    public enum GameState { loading, active };

    private GameObject musicManager, soundManager;

    // Will be set in game world before everything is run
    public GameObject mainCamera;
    
    // Temporary addition for music since other levels weren't considered before
    public AudioClip[] layerTracks;
	// Use this for initialization
	void Start () {
		// Instantiate internal managers
		gui = gameObject.AddComponent<GUIManager>();
        musicManager = (GameObject) Instantiate(Resources.Load(ResourcePaths.musicManager), Vector3.zero, Quaternion.identity);
        musicManager.transform.SetParent(transform);
        soundManager = (GameObject) Instantiate(Resources.Load(ResourcePaths.soundManager), Vector3.zero, Quaternion.identity);
        soundManager.transform.SetParent(transform);
        music = musicManager.GetComponent<MusicManager>();
        sound = soundManager.GetComponent<SoundManager>();
        objects = gameObject.AddComponent<ObjectManager>();
		levels = gameObject.AddComponent<LevelGenerator>();
        art = gameObject.GetComponent<LayerManager>();
		reactionTable = new ReactionTable();

        PopulateReactionTable();
      
        if(layerTracks.Length > 0)
        {
            music.clips = layerTracks;
        }
        //Find camera if not explicitly done in the Editor (this is a failsafe.. shouldn't rely on this)
        if (!mainCamera)
        {
            mainCamera = GameObject.Find("Main Camera");
        }

        // Start first level
        state = GameState.loading;
        

        //This is just so the old "Gameplay" scene doesn't break
        #pragma warning disable 0618 // Type or member is obsolete
        if(Application.loadedLevelName == "Gameplay")
        {
            worldProperties = gameObject.AddComponent<WorldProperties>();
            levels.CreateSampleLevel();

            // Set the camera to follow the game's player
            mainCamera.GetComponent<CameraFollow>().SetPlayer(ref worldProperties.player);
        }
        #pragma warning restore 0618 // Type or member is obsolete
    }

    public MusicManager getMusicManager()
    {
        return musicManager.GetComponent<MusicManager>();
    }

    public SoundManager getSoundManager()
    {
        return soundManager.GetComponent<SoundManager>();
    }

    public ReactionTable getReactionTable()
    {
        return reactionTable;
    }

    //All of the reaction data and entries will be initialized and populated here
    private void PopulateReactionTable()
    {
        //Setup the table!
        //The way this works is that collisions between molecules concatenate the MoleculeIDs, and that
        //is mapped to a product in the reaction table.

        //Lt = Low Temp, Mt = Med Temp, Ht = Hi Temp
        //Lp = Low Pres, Mp = Med Pres, Hp = Hi Pres

        //Lab Tutorial
        reactionTable.table["CC"] = "C";
        //Air
        reactionTable.table["CO2"] = "CO2";
        reactionTable.table["O2C"] = "CO2";

        reactionTable.table["CO2H2O"] = "O2";

        reactionTable.table["O2SO"]  = "SO2";
        reactionTable.table["SOO2"]  = "SO2";
        reactionTable.table["SO2O2"] = "SO3";

        //Transition Air->Water
        reactionTable.table["CO2Mt"] = "WaterCO2";

        //Water
        reactionTable.table["WaterCO2"] = "H2CO3";
        reactionTable.table["HCO3-H+"]  = "H2CO3";
        reactionTable.table["CO32-H+"]  = "HCO3-";

        reactionTable.table["CO2H2OMt"] = "CH2O"; // To get to Bathypelagic

        reactionTable.table["CO2CAO"] = "CaCO3";

        reactionTable.table["CO2H2OMt"] = "CH2O";

        reactionTable.table["H2CO3MtMp"] = "CO2";
        reactionTable.table["HCO3-H2O"]  = "CO32-";
        
        reactionTable.table["H2CO3H2O"] = "HCO3-";
        reactionTable.table["CaCO3H2O"] = "HCO3-";
        reactionTable.table["CaCO3CO2"] = "HCO3-";

        //Transition Water->Mantle
        reactionTable.table["CO2CA2+LtMp"] = "MantleCaCO3";
        reactionTable.table["CO2CAOLtMp"]  = "MantleCaCO3";
        
        
        //Mantle
        reactionTable.table["MantleCaCO3MtMp"] = "MantleCO2";
        reactionTable.table["MantleCO2H2O"]    = "MantleH2CO3";

        reactionTable.table["MantleH2CO3MtMp"] = "MantleHCO3-";
        reactionTable.table["MantleHCO3-LtHp"] = "CO32-";
        reactionTable.table["MantleHCO3-CAO"]  = "MantleCaCO3";
        reactionTable.table["CO32-MG2+"]       = "MGCO3";
        reactionTable.table["MantleCaCO3MtMp"] = "MantleCO2";

        reactionTable.table["MantleCO2HtHp"] = "CGraphite";

        reactionTable.table["CGraphiteHtHp"] = "CDiamond";

        reactionTable.table["MGCO3HtHp"] = "CDiamond";
        reactionTable.table["MGCO3HtHp"] = "CDiamond";

    }

	// where should this functionality really go?
	private void ShowLevel() {
		state = GameState.active;
		// art . transition from loading to world view
		// give player control?
	}
}
