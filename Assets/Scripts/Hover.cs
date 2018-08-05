using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    float startPosition;
    float endPosition;
    bool moveToRed;

    public GameObject lerpingObject;
    public Transform blueMarker;
    public Transform redMarker;
    public float lerpSpeed = .1f;
    public Material lerpingBallMaterial;

    public float t = 1;
    public float timeSpentLerping;
    public float maxDistanceBeforeLerpBack = .5f;
    
    
    void Start () {
        moveToRed = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Vector3.Distance(redMarker.position, transform.position));

            if (Vector3.Distance(transform.position, blueMarker.position) <= maxDistanceBeforeLerpBack)
            {
                ResetLerpVariables();
                moveToRed = true;
            }
            else if (Vector3.Distance(transform.position, redMarker.position) <= maxDistanceBeforeLerpBack)
            {
                ResetLerpVariables();
                moveToRed = false;
            }
        }

        t = timeSpentLerping;

        if (moveToRed)
        {
            MoveToRed();
        }
        else
        {
            MoveToBlue();
        }
    }

    void MoveToRed ()
    {
        lerpingBallMaterial.color = Color.red;
        lerpingBallMaterial.SetColor("_EmissionColor", Color.red);
        gameObject.GetComponent<Light>().color = Color.red;
        transform.position = Vector3.Lerp(transform.position, redMarker.position, lerpSpeed * t);
        timeSpentLerping++;
    }

    void MoveToBlue ()
    {
        lerpingBallMaterial.color = Color.blue;
        lerpingBallMaterial.SetColor("_EmissionColor", Color.blue);
        gameObject.GetComponent<Light>().color = Color.blue;
        transform.position = Vector3.Lerp(transform.position, blueMarker.position, lerpSpeed * t);
        timeSpentLerping++;
    }

    void ResetLerpVariables()
    {
        timeSpentLerping = 1;
        t = 1;
    }
}
