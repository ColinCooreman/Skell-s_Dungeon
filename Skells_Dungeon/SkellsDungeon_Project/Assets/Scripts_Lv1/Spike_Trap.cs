using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private Transform transSpikes = null;
    [SerializeField]
    private float _Speed = 5;
    private float _Timer = 0;
    private float _stopTimer = 0;

    [SerializeField]
    private Transform destination = null;
    private Vector3 startPos;
    [SerializeField]
    private float _waitTime = 0.0f;
    [SerializeField]
    private float _StopTime = 0.6f;
    bool _spikesUp = true;
    void Start ()
    {
        startPos = transSpikes.localPosition;
        _Timer = -_waitTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Game_Manager.Instance().getRedActive() == true)
        {
            _Timer += Time.deltaTime;

            if (_Timer > 0)
            {
                if (_spikesUp == true)
                {
                    if (transSpikes.localPosition.y <= destination.localPosition.y)
                    {
                        transSpikes.Translate(0, 0, Time.deltaTime * _Speed);
                    }
                    else
                    {
                        _stopTimer += Time.deltaTime;
                    }
                }
                else 
                {
                    if (transSpikes.localPosition.y >= startPos.y)
                    {
                        transSpikes.Translate(0, 0, -(Time.deltaTime * _Speed));
                    }
                    else
                    {
                        _stopTimer += Time.deltaTime;
                    }
                }

            }
        }
        else
        {
            if (transSpikes.localPosition.y <= startPos.y)
            { 
                transSpikes.Translate(0, 0,0);
            }
            _Timer = 0;
        }

        if(_stopTimer > _StopTime)
        {
            _spikesUp = !_spikesUp;
            _stopTimer = 0;
        }
    }
}
