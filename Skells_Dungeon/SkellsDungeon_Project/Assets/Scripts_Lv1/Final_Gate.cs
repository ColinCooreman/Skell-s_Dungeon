using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_Gate : MonoBehaviour
{

    [SerializeField]
    private Transform _EndPos;
    [SerializeField]
    private GameObject _Gate;
    private bool _gateUp = false;
    [SerializeField]
    float _MovSpeed = 1.5f;

    [SerializeField]
    GameObject RedGem;
    [SerializeField]
    GameObject BlueGem;
    [SerializeField]
    GameObject GreenGem;
    [SerializeField]
    GameObject PurpleGem;
    private float Timer;
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(_gateUp == true)
        {
            Timer += Time.deltaTime;
            if(Timer >= 1)
            {
                RedGem.SetActive(true);
            }
            if (Timer >= 2)
            {
                BlueGem.SetActive(true);
            }
            if (Timer >= 3)
            {
                GreenGem.SetActive(true);
            }
            if (Timer >= 4)
            {
                PurpleGem.SetActive(true);
            }
            if(Timer > 4.2)
            {

                if (_Gate.transform.localPosition.y <= _EndPos.localPosition.y)
                {
                    _Gate.transform.Translate(new Vector3(0, 0, Time.deltaTime * _MovSpeed));
                }
                else
                {
                    _gateUp = false;
                }
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>().GetPowerGemTotal() >= 4)
        {
            _gateUp = true;
            Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>().RemovePowerGem(4);
        }
    }


}
