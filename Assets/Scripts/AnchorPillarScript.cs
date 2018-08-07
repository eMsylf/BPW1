using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPillarScript : MonoBehaviour {

    public GameObject blueLamp;
    public GameObject redLamp;

    public bool containsBlueLamp = false;
    public Transform blueMarker;
    public bool containsRedLamp = false;
    public Transform redMarker;

    private Vector3 pillarPosition;

    // Use this for initialization
    void Start ()
    {
        pillarPosition = gameObject.transform.position;

        containsBlueLamp = false;
        containsRedLamp = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        containsBlueLamp = pillarPosition == blueMarker.position;
        containsRedLamp = pillarPosition == redMarker.position;

        blueLamp.SetActive(containsBlueLamp);
        redLamp.SetActive(containsRedLamp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (!containsBlueLamp && !containsRedLamp)
        {
            if (collisionObject.name.StartsWith("FlareBlue"))
            {
                blueMarker.position = pillarPosition;

                Debug.Log("Pillar hit by blue marker");
            }
            if (collisionObject.name.StartsWith("FlareRed"))
            {
                redMarker.position = pillarPosition;
                Debug.Log("Pillar hit by red marker");
            }
        }

        else if (containsBlueLamp && collisionObject.name.StartsWith("FlareRed"))
        {
            blueMarker.position = redMarker.position;
            redMarker.position = pillarPosition;
        }
        else if (containsRedLamp && collisionObject.name.StartsWith("FlareBlue"))
        {
            redMarker.position = blueMarker.position;
            blueMarker.position = pillarPosition;
        }

    }
}
