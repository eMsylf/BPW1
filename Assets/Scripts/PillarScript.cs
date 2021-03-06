﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour {

    public bool pillarIsOn;

    private Renderer pillarRenderer;
    private Light pillarLight;

    public AudioSource ding;
    public AudioSource dong;
    Material mat;

    //[SerializeField] private Material pillarMaterial;

    void Start()
    {
        pillarRenderer = GetComponent<Renderer>();
        pillarLight = GetComponent<Light>();
        mat = pillarRenderer.material;
    }

    private void Update()
    {
        //pillarMaterial = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {

        //Turns pillars that are touched on or off
        if (other.name.Contains("LerpingObject"))
        {
            pillarIsOn = !pillarIsOn;
            Debug.Log("Pillar" + name + "Hit");
            //Switch light
            pillarLight.enabled = pillarIsOn;

            //Switch emission on/off
            if (pillarIsOn)
            {
                TurnPillarOn();
            }
            else
            {
                TurnPillarOff();
            }
        }
    }

    public void TurnPillarOn()
    {
        ding.Play();
        mat.EnableKeyword("_EMISSION");
    }

    public void TurnPillarOff()
    {
        dong.Play();
        mat.DisableKeyword("_EMISSION");
    }
}
