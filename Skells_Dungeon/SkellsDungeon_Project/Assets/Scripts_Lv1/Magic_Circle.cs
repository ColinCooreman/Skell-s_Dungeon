using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Circle : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float _speed = 5.0f;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(0,Time.deltaTime * _speed, 0);
	}
}
