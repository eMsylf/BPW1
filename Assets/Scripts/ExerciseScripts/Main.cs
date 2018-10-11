using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace les2
{
    public class Main : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray r = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, .1f, Input.mousePosition.y));
                //RaycastHit hit;
                //if (Physics.Raycast(r, out hit))
            }
        }
    }
}