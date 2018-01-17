using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private int damage = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>().RemoveHealth(damage);
    }

}
