using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private float _MaxTime = 6.0f;
    private float _Timer;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        _Timer += Time.deltaTime;
        if(_Timer <= _MaxTime && this.gameObject != null)
        {
            this.transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            Destroy(this.gameObject);
        }
      
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Character_Ctrl>().RemoveHealth(_damage);
            Destroy(this.gameObject);
        }
    }
}
