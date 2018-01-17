using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_spell : MonoBehaviour
{

    // Use this for initialization
    private GameObject _player;
    private float _newSpeed;
    void Start()
    {
        _player = Game_Manager.Instance().getPlayer();
        _newSpeed = _player.GetComponent<Character_Ctrl>().GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            _player.GetComponent<CharacterController>().stepOffset = 0.001f;
            _player.GetComponent<CharacterController>().radius = 0.30f;
            _player.GetComponent<Character_Ctrl>().SetSpeed(_newSpeed/3);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            _player.GetComponent<CharacterController>().stepOffset = 0.4f;
            _player.GetComponent<CharacterController>().radius = 0.48f;
            _player.GetComponent<Character_Ctrl>().SetSpeed(_newSpeed);
        }

    }
}
