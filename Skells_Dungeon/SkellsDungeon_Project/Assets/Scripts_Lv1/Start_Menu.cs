using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Start_Menu : MonoBehaviour {

    // Use this for initialization
    //[SerializeField]
    //private GameObject _Panel_Loading = null;
    //[SerializeField]
    //private GameObject _Panel_Controls = null;
    //[SerializeField]
    //private GameObject _Panel_Options = null;

    [SerializeField]
    private Button _btn_Quit = null;

    [SerializeField]
    private Button _btn_Options = null;

    [SerializeField]
    private Button _btn_Credits = null;

    [SerializeField]
    private Button _btn_Start= null;

    void Start ()
    {
        _btn_Start.onClick.AddListener(mainMenuPlay);
        _btn_Options.onClick.AddListener(Options);
        _btn_Credits.onClick.AddListener(Credits);
        _btn_Quit.onClick.AddListener(MainMenuExit);
    }
    void mainMenuPlay()
    {
        PlayLevel("Level1");
    }
    void Options()
    {
        //_Panel_Options.SetActive(true);
    }
    void MainMenuExit()
    {
        Application.Quit();
    }
    private void PlayLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    private void Credits()
    {
        SceneManager.LoadScene("End_Screen");
    }
}
