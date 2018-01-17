using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_d20 : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float _speed = 2.0f;
    private float _rotate;

    private GameObject player;

    //enum DiceOrGem
    //{
    //    D20,
    //    Powergem
    //}
    //[SerializeField]
    //DiceOrGem type;
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        _rotate = Time.deltaTime * _speed;
        this.transform.Rotate(0, 0, _rotate);
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {

            col.GetComponent<Character_Ctrl>().AddDice(1);
            
            //if (type == DiceOrGem.Powergem)
            //{
            //    col.GetComponent<Character_Ctrl>().AddPowerGem(1);
            //}
            Destroy(this.gameObject);
        }
    }
}
