﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMarkerManager : MonoBehaviour {

    public bool ayyLmao;

    public List<GameObject> Children;

    public GameObject blueMarker;
    public GameObject redMarker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ayyLmao)
        {
            foreach (GameObject child in transform)
            {
                child.SetActive(false);
            }
            Children.Clear();
            ayyLmao = false;
        }
	}
}
