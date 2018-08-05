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

    [SerializeField] private Material pillarMaterial;

    private void Awake()
    {
        pillarState = true;
        pillarPosition = gameObject.transform.position;
    }

    private void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        pillarMaterial = renderer.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.name.Equals("LerpingObject"))
        {
            Debug.Log("Pillar switch");
            if (pillarState)
            {
                pillarMaterial.SetColor("_EmissionColor", Color.black);
                gameObject.GetComponent<Light>().enabled = false;
                pillarState = false;
            }
            else
            {
                pillarMaterial.SetColor("_EmissionColor", Color.white);
                gameObject.GetComponent<Light>().enabled = true;
                pillarState = true;
            }
            
            Debug.Log("Pillar hit by Lerping Object");
        }




        if (!containsBlueLamp && !containsRedLamp)
        {
            if (collisionObject.name.StartsWith("FlareBlue"))
            {
                containsBlueLamp = true;
                blueLamp.SetActive(true);
                blueMarker.position = pillarPosition;
                
                Debug.Log("Pillar hit by blue marker");
            }
            if (collisionObject.name.StartsWith("FlareRed"))
            {
                containsRedLamp = true;
                redLamp.SetActive(true);
                redMarker.position = pillarPosition;

                //redMarker.transform.position = gameObject.transform.position;
                Debug.Log("Pillar hit by red marker");
            }
        }


        else if (containsBlueLamp && collisionObject.name.StartsWith("FlareRed"))
        {
            blueLamp.SetActive(true);
            redLamp.SetActive(false);
            blueMarker.position = redMarker.position;
            redMarker.position = pillarPosition;
        }
        else if (containsRedLamp && collisionObject.name.StartsWith("FlareBlue"))
        {
            blueLamp.SetActive(false);
            redLamp.SetActive(true);
            redMarker.position = blueMarker.position;
            blueMarker.position = pillarPosition;
        }
        
    }
}
