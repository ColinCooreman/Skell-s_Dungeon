using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Leave_TheDungeon : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject Treasure_Char;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && Treasure_Char.activeSelf)
        {
            SceneManager.LoadScene("End_Screen");
        }

    }
}
