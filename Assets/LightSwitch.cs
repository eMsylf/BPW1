using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public Light flashLight;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { flashLight.enabled = !flashLight.enabled; }
    }
}
