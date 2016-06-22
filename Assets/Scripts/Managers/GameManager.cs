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
		reactionTable = new ReactionTable();

        //Find camera if not explicitly done in the Editor (this is a failsafe.. shouldn't rely on this)
        if (!mainCamera)
        {
            mainCamera = GameObject.Find("Main Camera");
        }

        // Start first level
        state = GameState.loading;
        PopulateReactionTable();

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

    //All of the reaction data and entries will be initialized and populated here
    private void PopulateReactionTable()
    {
        reactionTable.SetUpTable(new string[] { "C", "O2", "N2", "CO2"});
        ReactionTableEntry reaction1 = new ReactionTableEntry(new string[] { "CO2" });
        reactionTable.RegisterReaction("C", "O2", reaction1);
    }

	// where should this functionality really go?
	private void ShowLevel() {
		state = GameState.active;
		// art . transition from loading to world view
		// give player control?
	}
}
