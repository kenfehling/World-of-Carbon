using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TitleScreenHandler : MonoBehaviour {

    public GameObject[] menus;
    public uint currentMenu = 0;
	// Use this for initialization
	void Start () {
#if UNITY_ANDROID
        if(SceneManager.GetActiveScene().buildIndex == 0)
            Handheld.PlayFullScreenMovie("CarbonTitleSeq.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayCredits()
    {
#if UNITY_ANDROID
        Handheld.PlayFullScreenMovie("Credits.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
#endif
    }

    public void GoToMenu()
    {
        menus[0].SetActive(false);
        menus[1].SetActive(true);
        currentMenu = 1;
    }

    public void ToTopMenu()
    {
        menus[currentMenu].SetActive(false);
        currentMenu = 0;
        menus[currentMenu].SetActive(true);
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(2);
    }

    public void StartTheTutorial()
    {
        SceneManager.LoadScene(1);

    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene(0);

    }
    
    public void SetColor(string color)
    {
        ColorTracker.SetMolColor(color);
    }
}
