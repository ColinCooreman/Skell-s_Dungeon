using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPedastal : MonoBehaviour 
{

    // Use this for initialization

    [SerializeField]
    GameObject PowerGem;
    [SerializeField]
    Game_Manager.Powergem GemColor;
    private bool RedActive;
    private bool BlueActive;
    private bool GreenActive;
    private bool PurpleActive;
    private Character_Ctrl player;
    bool once = false;
    private float _timer;
    void Start()
    {

        player = Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>();
    }

    // Update is called once per frame
    void Update()
    {

       if(once == true)
        {
            _timer += Time.deltaTime;
            if(_timer >= 3)
            {
                once = false;
            }
        }

        RedActive = Game_Manager.Instance().getRedActive();
        BlueActive = Game_Manager.Instance().getBlueActive();
        GreenActive = Game_Manager.Instance().getGreenActive();
        PurpleActive = Game_Manager.Instance().getPurpleActive();
    }

    void OnTriggerStay(Collider col)
    {
        switch (GemColor)
        {
            case Game_Manager.Powergem.Red:
                if (once == false)
                {
                    if (col.tag == "Player")
                    {
                        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && RedActive)
                        {
                            PowerGem.SetActive(false);
                            player.AddPowerGem(1);
                            once = true;
                        }
                        else if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && RedActive == false)
                        {
                            PowerGem.SetActive(true);
                            player.RemovePowerGem(1);
                            once = true;
                        }

                    }
                }
 
                break;
            case Game_Manager.Powergem.Blue:
                if (col.tag == "Player")
                {
                    if (once == false)
                    {
                        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && BlueActive)
                        {
                            PowerGem.SetActive(false);
                            player.AddPowerGem(1);
                            once = true;
                        }
                        else if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && BlueActive == false)
                        {
                            PowerGem.SetActive(true);
                            player.RemovePowerGem(1);
                            once = true;
                        }
                    }
                }
                break;
            case Game_Manager.Powergem.Green:
                if (col.tag == "Player")
                {
                    if (once == false)
                    {
                        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && GreenActive)
                        {
                            PowerGem.SetActive(false);
                            player.AddPowerGem(1);
                            once = true;
                        }
                        else if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && GreenActive == false)
                        {
                            PowerGem.SetActive(true);
                            player.RemovePowerGem(1);
                            once = true;
                        }
                    }
                }
                break;
            case Game_Manager.Powergem.Purple:
                if (col.tag == "Player")
                {
                    if (once == false)
                    {
                        if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && PurpleActive)
                        {
                            PowerGem.SetActive(false);
                            player.AddPowerGem(1);
                            once = true;
                        }
                        else if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0") && PurpleActive == false)
                        {
                            PowerGem.SetActive(true);
                            player.RemovePowerGem(1);
                            once = true;
                        }
                    }
                }
                break;
        }
        
    }

}


