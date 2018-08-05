using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShootScript : MonoBehaviour {

    public float fireRate = .25f;
    public float range = 50;
    public ParticleSystem smokeParticles;
    public GameObject hitParticles;
    public GameObject shootFlare;
    public int damage = 1;

    private Camera fpsCam;
    //private LineRenderer lineRenderer;
    //private WaitForSeconds shotLength = new WaitForSeconds(.7f);
    //private AudioSource source;
    private float nextFireTime;

    void Awake()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        //source = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }
	
	void Update () {
        RaycastHit hit;
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
            {
                EnemyHealth dmgScript = hit.collider.gameObject.GetComponent<EnemyHealth>();
                if (dmgScript != null)
                {
                    dmgScript.Damage(damage, hit.point);
                }
            }
        }
	}
}
