using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treaseure_chest : MonoBehaviour {

    // Use this for initialization

    private bool _OpenTreasureChest = false;

    private bool _TreasureCollected = false;
    private float Timer;
    private bool once = false;

    [SerializeField]
    private GameObject Treasure;
    [SerializeField]
    private Animator ChestAnimation;
    [SerializeField]
    private GameObject _Treasure_On_Char;
    private bool _TreasureOnce = false; 
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(_OpenTreasureChest)
        {

            Timer += Time.deltaTime;
            //play chest animation
            ChestAnimation.SetTrigger("Open");
            

            if(Timer >= 6)
            {
                _TreasureCollected = true;
                _OpenTreasureChest = false;
            }
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if(once == false)
            {
                _OpenTreasureChest = true;
                once = true;
            }
           
        }

    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (_TreasureOnce == false)
            {
                if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0"))
                {
                    Treasure.SetActive(false);
                    _Treasure_On_Char.SetActive(true);
                    _TreasureOnce = true;
                }
            }
        }
    }
    public bool GetTreasureStatus()
    {
        return _TreasureCollected;
    }
}
