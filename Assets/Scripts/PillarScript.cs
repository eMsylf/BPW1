using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour {

    public GameObject redLamp;
    public GameObject blueLamp;

    public bool containsBlueLamp = false;
    public Transform blueMarker;
    public bool containsRedLamp = false;
    public Transform redMarker;

    public bool pillarState;
    private Vector3 pillarPosition;

    //[SerializeField] private Material pillarMaterial;

    private void Awake()
    {
        pillarState = true;
        pillarPosition = gameObject.transform.position;
    }

    private void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        //pillarMaterial = renderer.material;

        if (pillarPosition == blueMarker.position)
        {
            containsBlueLamp = true;
        }
        else
        {
            containsBlueLamp = false;
        }
        if (pillarPosition == redMarker.position)
        {
            containsRedLamp = true;
        }
        else
        {
            containsRedLamp = false;
        }

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
