using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Trap : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject Fake_Floor;

    [SerializeField]
    private GameObject Real_Floor;

    [SerializeField]
    private GameObject Final_Floor;

    [SerializeField]
    private GameObject Slowspell;

    [SerializeField]
    private GameObject Magic_Ring;
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Game_Manager.Instance().getPurpleActive() == true)
        {
            Slowspell.SetActive(true);
            Magic_Ring.SetActive(true);

            Real_Floor.SetActive(true);
            Fake_Floor.SetActive(true);
            Final_Floor.SetActive(false);

        }
        else
        {
            Slowspell.SetActive(false);
            Magic_Ring.SetActive(false);

            Real_Floor.SetActive(false);
            Fake_Floor.SetActive(false);
            Final_Floor.SetActive(true);
        }
	}
}
