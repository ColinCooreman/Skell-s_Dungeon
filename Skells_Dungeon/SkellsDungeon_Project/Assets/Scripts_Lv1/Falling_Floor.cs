using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Floor : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float range = 1.0f; //how fast it shakes
    [SerializeField]
    private float _shakeInterval = 0.2f;
    [SerializeField]
    private float _shakeTimeMax = 2.0f;
    [SerializeField]
    private  float _fallSpeed = 0.2f;
    private Vector3 _startPos;
    private float _shakeTime;
    private float _time;
    private bool _dropFloor = false;
    private bool _Destroy = false;

    void Start()
    {
        _startPos = this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (_Destroy == false)
        {
            if (_dropFloor == true)
            {
                _shakeTime += Time.deltaTime;
                _time += Time.deltaTime;
                if (_shakeTime <= _shakeTimeMax)
                {

                    _time += Time.deltaTime;
                    if (_time > _shakeInterval)
                    {
                        this.transform.position = _startPos + Random.insideUnitSphere * range;
                        _time = 0;
                    }
                }

                else
                {
                    this.transform.Translate(0, -_fallSpeed, 0);
                }
            }

        }
        else
        {
            Destroy(this.gameObject);
        }

        if(this.transform.position.y <= -6.5)
        {
            _Destroy = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            _dropFloor = true;
        }
    }
}