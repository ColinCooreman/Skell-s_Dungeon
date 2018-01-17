using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : Singleton<Game_Manager>
{

    // Use this for initialization
    [SerializeField]
    private GameObject _player;
    private Character_Ctrl _playercrtl;
    [SerializeField]
    private Treaseure_chest _chest;
    bool Treasure = false;
    [SerializeField]
    private GameObject Camera;
    public enum Powergem
    {
        Red,
        Blue,
        Green,
        Purple
    }
    [SerializeField]
    private GameObject RedGem;
    [SerializeField]
    private GameObject BlueGem;
    [SerializeField]
    private GameObject GreenGem;
    [SerializeField]
    private GameObject PurpleGem;

    private bool _RedActive = true;
    private bool _BlueActive = true;
    private bool _GreenActive = true;
    private bool _PurpleActive = true;
    void Start ()
    {
        _playercrtl = _player.GetComponent<Character_Ctrl>();
        //        _uiCtrl = _UI.GetComponent<Control_UI>();
    }

    // Update is called once per frame
    void Update ()
    {
        Treasure = _chest.GetTreasureStatus();
        //red gem
        if (!RedGem.activeSelf)
        {
            _RedActive = false;
        }
        else
        {
            _RedActive = true;
        }

        //blue gem
        if (!BlueGem.activeSelf)
        {
            _BlueActive = false;
        }
        else
        {
            _BlueActive = true;
        }

        //green gem
        if (!GreenGem.activeSelf)
        {
            _GreenActive = false;
        }
        else
        {
            _GreenActive = true;
        }

        //purple gem
        if (!PurpleGem.activeSelf)
        {
            _PurpleActive = false;
        }
        else
        {
            _PurpleActive = true;
        }
    }

    public GameObject getPlayer()
    {
        return _player;
    }
    public GameObject getCamera()
    {
        return Camera;
    }

    public bool getRedActive()
    {
        return _RedActive;
    }
    public bool getBlueActive()
    {
        return _BlueActive;
    }
    public bool getGreenActive()
    {
        return _GreenActive;
    }
    public bool getPurpleActive()
    {
        return _PurpleActive;
    }
    public bool GetTreasurebool()
    {
        return Treasure;
    }
}
