using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_Script : MonoBehaviour
{

    // Use this for initialization

    [SerializeField]
    private Button _btn_Quit = null;

    [SerializeField]
    private Button _btn_MainMenu = null;

    void Start ()
    {
        Time.timeScale = 1;
        _btn_MainMenu.onClick.AddListener(mainMenuPlay);
        _btn_Quit.onClick.AddListener(MainMenuExit);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = 1;

    }

    void mainMenuPlay()
    {
        Time.timeScale = 1;
        PlayLevel("Start_Screen");

    }

    void MainMenuExit()
    {
        Application.Quit();
    }
    private void PlayLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
