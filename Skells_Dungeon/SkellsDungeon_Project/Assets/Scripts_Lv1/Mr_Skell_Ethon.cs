using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr_Skell_Ethon : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private Transform transSelf;

    [SerializeField]
    private Transform[] arrWayPoints;
    [SerializeField]
    private float _speed = 8;
    private int _CurrentWayP = 0;
    private bool _PlayerInRange = false;
    [SerializeField]
    private Animator SkellAnimator;
    private Vector3 lookat = new Vector3(0, 0, 0);

    [SerializeField]
    private GameObject SkellyHelp1 = null;
    [SerializeField]
    private GameObject SkellyHelp2 = null;
    [SerializeField]
    private GameObject SkellyHelp3 = null;
    [SerializeField]
    private GameObject SkellyHelp4 = null;
    [SerializeField]
    private GameObject SkellyHelp5 = null;
    private bool skellyOnce1 = false;
    private bool skellyOnce2 = false;
    private bool skellyOnce3 = false;
    private bool skellyOnce4= false;
    private bool skellyOnce5 = false;

    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if((Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 0")))
        {
            SkellyHelp1.SetActive(false);
            SkellyHelp2.SetActive(false);
            SkellyHelp3.SetActive(false);
            SkellyHelp4.SetActive(false);
            SkellyHelp5.SetActive(false);
        }
       if(_CurrentWayP == 0)
        {
            if(skellyOnce1 == false)
            {
                SkellyHelp1.SetActive(true);
                skellyOnce1 = true;
            }
        }

        if (_CurrentWayP == 1)
        {
            if (skellyOnce2 == false)
            {
                SkellyHelp2.SetActive(true);
                skellyOnce2 = true;
            }
        }
        if (_CurrentWayP == 2)
        {
            if (skellyOnce3 == false)
            {
                SkellyHelp3.SetActive(true);
                skellyOnce3 = true;
            }
        }
        if (_CurrentWayP == 6)
        {
            if (skellyOnce4 == false)
            {
                SkellyHelp4.SetActive(true);
                skellyOnce4 = true;
            }
        }
        if (_CurrentWayP == 8)
        {
            if (skellyOnce5 == false)
            {
                SkellyHelp5.SetActive(true);
                skellyOnce5 = true;
            }
        }

        if (_CurrentWayP < arrWayPoints.Length - 1)
        {
            if (transSelf.position == arrWayPoints[_CurrentWayP].position)
            {
                SkellAnimator.SetTrigger("Talk1");
                if (_CurrentWayP != 0 && _CurrentWayP != 1 && _CurrentWayP != 2 && _CurrentWayP != 4 && _CurrentWayP != 7 || _PlayerInRange == true)
                {
                         NextWayPoint();
                        _PlayerInRange = false;
                }

            }
            else
            {
  
                SkellAnimator.SetTrigger("Running");
               
            }
            transSelf.position = Vector3.MoveTowards(transSelf.position, arrWayPoints[_CurrentWayP].position, _speed * Time.deltaTime);
            if(_CurrentWayP != 2 && _CurrentWayP != 4 && _CurrentWayP != 7)
            {
                lookat = Vector3.Lerp(transSelf.position + transSelf.forward, arrWayPoints[_CurrentWayP].position, Time.deltaTime * 2.0f);
            }
     
                    
            transSelf.LookAt(lookat);

        }
        SkellAnimator.SetTrigger("Talk1");
    }

    void NextWayPoint()
    {
        ++_CurrentWayP;
        if (_CurrentWayP >= arrWayPoints.Length)
        {
            _CurrentWayP = arrWayPoints.Length;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            _PlayerInRange = true;
        }
    }

}
