using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public Light flashLight;
    public KeyCode flashLightToggle;

    void Update()
    {
        if (Input.GetKeyDown(flashLightToggle)) { flashLight.enabled = !flashLight.enabled; }
    }
}
