using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour {

    public GameObject redLamp;
    public GameObject blueLamp;
    public bool pillarState;

    [SerializeField] private Material pillarMaterial;

    private void Awake()
    {
        pillarState = true;
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

        else if (collisionObject.name.StartsWith("FlareBlue"))
        {
            blueLamp.SetActive(true);

            Debug.Log("Pillar hit by blue marker");
        }
        else if (collisionObject.name.StartsWith("FlareRed"))
        {
            redLamp.SetActive(true);
            //redMarker.transform.position = gameObject.transform.position;
            Debug.Log("Pillar hit by red marker");
        }
        
    }
}
