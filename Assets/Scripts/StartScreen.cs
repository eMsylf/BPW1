using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {

    public GameObject Overlay;
    public GameObject Text;
    public Rigidbody FPSController_rb;

    public bool freezeControls;


	// Use this for initialization
	void Start () {
        freezeControls = true;
        FPSController_rb.constraints = RigidbodyConstraints.FreezePosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (freezeControls)
        {
            FPSController_rb.constraints = RigidbodyConstraints.FreezePosition;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Overlay.GetComponent<Animation>().Play();
                freezeControls = false;
            }
        }
        else
        {
            FPSController_rb.constraints = RigidbodyConstraints.None;
        }
	}


}
