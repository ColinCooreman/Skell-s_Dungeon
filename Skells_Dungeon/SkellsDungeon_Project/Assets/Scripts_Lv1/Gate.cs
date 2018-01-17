using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private bool _gateUp = false;
    [SerializeField]
    private GameObject _Gate;
    [SerializeField]
    private Transform EndPos;
    [SerializeField]
    private float MovSpeed = 1.5f;
    private Vector3 startPos;
    private float Timer;
	// Use this for initialization
	void Start ()
    {
        startPos = _Gate.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Game_Manager.Instance().GetTreasurebool() == true)
        {
            _gateUp = true;
        }
        if (_gateUp == false)
        {
            Timer = 0;
            if (_Gate.transform.localPosition.z > startPos.z)
            {
                _Gate.transform.Translate(new Vector3(0, 0, -Time.deltaTime * MovSpeed));
            }

        }
        else
        {
            if(Game_Manager.Instance().GetTreasurebool() == false)
            {
                Timer += Time.deltaTime;
            }

  

            if (_Gate.transform.localPosition.z <= EndPos.localPosition.z)
            {
                _Gate.transform.Translate(new Vector3(0, 0, Time.deltaTime * MovSpeed));
            }
            if (Timer >= 10)
            {
                _gateUp = false;
                
            }
        }
      

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            _gateUp = true;
        }
    }
}
