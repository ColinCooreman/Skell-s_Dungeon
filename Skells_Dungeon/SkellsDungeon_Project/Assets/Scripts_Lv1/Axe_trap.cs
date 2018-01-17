using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_trap : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float _max_rot = 80.0f;
    [SerializeField]
    private float _speed = 80.0f;
    private float _rot;
    [SerializeField]
    private Transform _axeBlade;
    private bool _switch = true;
    [SerializeField]
    private int damage = 5;
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Game_Manager.Instance().getGreenActive() == true)
        {
            _rot = _axeBlade.rotation.z * Mathf.Rad2Deg * Mathf.PI;

            if (_switch == true)
            {
                _axeBlade.Rotate(0, 0, _speed * Time.deltaTime);
            }
            else
            {
                _axeBlade.Rotate(0, 0, -_speed * Time.deltaTime);
            }
            if (_rot >= _max_rot)
            {
                _switch = false;
            }
            else if (_rot <= -_max_rot)
            {
                _switch = true;
            }
        }


    }
    void OnTriggerEnter(Collider col)
    {
        if (Game_Manager.Instance().getGreenActive() == true)
        {
            Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>().RemoveHealth(damage);
        }
    }

}
