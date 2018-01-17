using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianaStone : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private Transform transSelf;
    [SerializeField]
    private Transform _Stone;
    [SerializeField]
    private Transform[] arrWayPoints;
    [SerializeField]
    private float _speed = 8;
    private int _CurrentWayP = 0;

    private bool _IsTreasureTaken = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _IsTreasureTaken = Game_Manager.Instance().GetTreasurebool();

        if (_IsTreasureTaken == true && _CurrentWayP < arrWayPoints.Length-1)
        {
            _Stone.transform.Rotate(new Vector3(Time.deltaTime * _speed * 80, 0, 0));
            if (transSelf.position == arrWayPoints[_CurrentWayP].position)
            {
                NextWayPoint();
            }
            transSelf.position = Vector3.MoveTowards(transSelf.position, arrWayPoints[_CurrentWayP].position, _speed * Time.deltaTime);
            Vector3 lookat = Vector3.Lerp(transSelf.position + transSelf.forward, arrWayPoints[_CurrentWayP].position, Time.deltaTime * 2.0f);
            transSelf.LookAt(lookat);
        
        }
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
        if(col.tag == "Player")
        {
            Game_Manager.Instance().getPlayer().GetComponent<Character_Ctrl>().RemoveHealth(100);
        }
    }




}
