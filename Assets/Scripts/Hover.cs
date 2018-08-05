using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    float startPosition;
    float endPosition;
    bool moveToRed;

    public GameObject lerpingObject;
    public Transform startMarker;
    public Transform endMarker;
    public float lerpSpeed = .1f;
    public Material lerpingBallMaterial;

    public float t = 1;
    public float timeSpentLerping;
    
    
    void Start () {
        moveToRed = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position == startMarker.position)
            {
                ResetLerpVariables();
                moveToRed = true;
            }
            else if (transform.position == endMarker.position)
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
        transform.position = Vector3.Lerp(transform.position, endMarker.position, lerpSpeed * t);
        timeSpentLerping++;
    }

    void MoveToBlue ()
    {
        lerpingBallMaterial.color = Color.blue;
        lerpingBallMaterial.SetColor("_EmissionColor", Color.blue);
        gameObject.GetComponent<Light>().color = Color.blue;
        transform.position = Vector3.Lerp(transform.position, startMarker.position, lerpSpeed * t);
        timeSpentLerping++;
    }

    void ResetLerpVariables()
    {
        timeSpentLerping = 1;
        t = 1;
    }
}
