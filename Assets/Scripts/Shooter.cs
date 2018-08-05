using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject flareRedPrefab;
    public GameObject flareBluePrefab;
    [Range(700.0f, 1500.0f)]
    public float shotSpeed = 1000.0f;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            FireRedFlare();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            FireBlueFlare();
        }

        /*
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hitInfo))
            {
                if (hitInfo.collider.gameObject.name.StartsWith("Target"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
        */
	}

    void FireRedFlare ()
    {
        GameObject flareRed = Instantiate(flareRedPrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody flareRigidbody = (Rigidbody)flareRed.GetComponent(typeof(Rigidbody));

        flareRigidbody.AddForce(transform.forward * shotSpeed);
    }

    void FireBlueFlare ()
    {
        GameObject flareBlue = Instantiate(flareBluePrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody flareRigidbody = (Rigidbody)flareBlue.GetComponent(typeof(Rigidbody));

        flareRigidbody.AddForce(transform.forward * shotSpeed);
    }
}
