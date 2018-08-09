using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    //float startPosition;
    //float endPosition;
    bool moveToRed;
    public bool moveAutomatically;

    public GameObject lerpingObject;
    private Rigidbody rb;

    private Vector3 movingToRed;
    private Vector3 movingToBlue;

    public Transform blueMarker;
    public Transform redMarker;
    public float lerpSpeed = .1f;
    public Material lerpingBallMaterial;

    public float t = 1;
    public float timeSpentLerping;
    public float maxDistanceBeforeLerpBack = .5f;
    
    void Start () {
        rb = lerpingObject.GetComponent<Rigidbody>();
        moveToRed = true;
        movingToRed = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.Space) || moveAutomatically)
        {
            //Debug.Log(Vector3.Distance(redMarker.position, transform.position));

            if (Vector3.Distance(transform.position, movingToBlue) <= maxDistanceBeforeLerpBack)
            {
                ResetLerpVariables();
                moveToRed = true;
                movingToRed = redMarker.position;
            }
            else if (Vector3.Distance(transform.position, movingToRed) <= maxDistanceBeforeLerpBack)
            {
                ResetLerpVariables();
                moveToRed = false;
                movingToBlue = blueMarker.position;
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
        rb.MovePosition(Vector3.Lerp(transform.position, movingToRed, lerpSpeed * t));
        timeSpentLerping++;
    }

    void MoveToBlue ()
    {
        lerpingBallMaterial.color = Color.blue;
        lerpingBallMaterial.SetColor("_EmissionColor", Color.blue);
        gameObject.GetComponent<Light>().color = Color.blue;
        rb.MovePosition(Vector3.Lerp(transform.position, movingToBlue, lerpSpeed * t));

        //transform.position = Vector3.Lerp(transform.position, blueMarker.position, lerpSpeed * t);
        timeSpentLerping++;
    }
    
    void ResetLerpVariables()
    {
        timeSpentLerping = 1;
        t = 1;
    }
}
