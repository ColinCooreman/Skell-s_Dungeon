using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    [SerializeField]
    Text _currentText;
    [SerializeField]
    Slider _HealthBar;
    [SerializeField]
    private Button _btn_Quit = null;

    [SerializeField]
    private Button _btn_MainMenu = null;
    private int currentscore = 0;
    private GameObject _Player;

    [SerializeField]
    private GameObject _PauseMenu = null;

    [SerializeField]
    private GameObject _NoRedGem = null;
    [SerializeField]
    private GameObject _NoBlueGem = null;
    [SerializeField]
    private GameObject _NoGreenGem = null;
    [SerializeField]
    private GameObject _NoPurpleGem = null;
    private bool _Paused = false; 
    // Use this for initialization
    void Start ()
    {
        //_currentText = gameObject.GetComponent<Text>();
        _btn_MainMenu.onClick.AddListener(mainMenuPlay);
        _btn_Quit.onClick.AddListener(MainMenuExit);
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentscore = Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>().GetDiceAmount();
        _currentText.text = "X" + currentscore;
        _HealthBar.value = Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>().GetHealth();
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown("joystick button 7"))
        {
            _Paused = !_Paused;
        }
        if (_Paused)
        {
            Time.timeScale = 0;
            _PauseMenu.SetActive(true);
        }
        else
        {
            _PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }


            _NoRedGem.SetActive(Game_Manager.Instance().getRedActive());
            _NoBlueGem.SetActive(Game_Manager.Instance().getBlueActive());
            _NoGreenGem.SetActive(Game_Manager.Instance().getGreenActive());
            _NoPurpleGem.SetActive(Game_Manager.Instance().getPurpleActive());
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
