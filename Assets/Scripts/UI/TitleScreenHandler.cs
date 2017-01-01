using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TitleScreenHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Handheld.PlayFullScreenMovie("CarbonTitleSeq.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayCredits()
    {
        Handheld.PlayFullScreenMovie("Credits.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);

    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(2);
    }

    public void StartTheTutorial()
    {
        SceneManager.LoadScene(1);

    }
}
