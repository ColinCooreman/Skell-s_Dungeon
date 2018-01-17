//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class GameMan: Singleton<GameMan>
//{
//    [SerializeField]
//    private GameObject _Player = null;

//    [SerializeField]
//    private GameObject _Heart = null;

//    [SerializeField]
//    private GameObject _Shield = null;

//    [SerializeField]
//    private GameObject _UI = null;

//    private bool _died = false;

//    private bool _LookAtMouse = false;

//    private float _timingAfterDeath = 0;
//    private float _timingAfterDeathMax = 5;

//    private Player_Ctrl _playerCtrl = null;
//    private Player_Input_Manager _playerInput = null;
//    private Heart _heartCtrl = null;
//    private HeartMove _heartMove = null;
//    private Control_UI _uiCtrl = null;

//    public enum WeaponType
//    {
//        SWORD,
//        HAMMER,
//        DAGGER,
//        SPIKEYHEAD,
//        BOW,
//        SPEAR
//    }

//    private void Start()
//    {
//        Physics.IgnoreLayerCollision(8, 9, true);
//        Physics.IgnoreLayerCollision(9, 10, true);

//        _playerCtrl = _Player.GetComponent<Player_Ctrl>();
//        _playerInput = _Player.GetComponent<Player_Input_Manager>();
//        _heartCtrl = _Heart.GetComponent<Heart>();
//        _heartMove = _Heart.GetComponent<HeartMove>();
//        _uiCtrl = _UI.GetComponent<Control_UI>();
//    }

//    private void Update()
//    {
//        if (!_died)
//        {
//            if (Input.GetKeyDown(KeyCode.O))
//            {
//                _playerCtrl.AddPoints(1000);
//            }
//            if (Input.GetKeyDown(KeyCode.L))
//            {
//                //Armour
//                _playerCtrl.AddArmor(100);
//            }
//            if (Input.GetKeyDown(KeyCode.K))
//            {
//                //Health
//                _heartCtrl.Health += 100;
//                _playerCtrl.AddHealth(100);
//            }

//            if (_heartCtrl.Health < 0 || _playerCtrl.GetHealth() < 0)
//            {
//                // death
//                gameObject.GetComponent<ItemSpawnManager>().enabled = false;
//                gameObject.GetComponent<Wave_Manager>().enabled = false;
//                gameObject.GetComponent<Enemy_Manager>().DisableEnemies();
//                _playerInput.LockInput = true;
//                _heartMove.IsLocked = true;
//                _died = true;
//                _uiCtrl.SetDeath();
//                _playerInput.SetDeath();
//            }
//        }
//        else
//        {
//            _timingAfterDeath += Time.deltaTime;
//            if (_timingAfterDeath >= _timingAfterDeathMax)
//            {
//                _uiCtrl.SetReset();
//                enabled = false;
//            }
//        }
//    }

//    // Update is called once per frame
//    public GameObject getPlayer()
//    {
//        return _Player;
//    }

//    public GameObject getHeart()
//    {
//        return _Heart;
//    }

//    public GameObject getShield()
//    {
//        return _Shield;
//    }

//    public bool LookAtMouse
//    {
//        get
//        {
//            return _LookAtMouse;
//        }
//        set
//        {
//            _LookAtMouse = value;
//        }
//    }
//}