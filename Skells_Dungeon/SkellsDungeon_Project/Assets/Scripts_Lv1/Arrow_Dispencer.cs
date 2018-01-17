using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Dispencer : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private Transform _SpawnPos;
    private float _Timer;
    private float _ResetTime = 0.2f;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {



	}

    void OnTriggerEnter(Collider col)
    {
        if(Game_Manager.Instance().getBlueActive() == true)
        {
            Instantiate(_projectile, _SpawnPos.position, _SpawnPos.rotation);
        }

    }
}
