using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareScript : MonoBehaviour {

    //public float destructionTime = 1f;
    //private ParticleSystem deathEffect;

    private float lifeTime = 200f;


    public bool blueMarkerCanBeMoved;
    public bool redMarkerCanBeMoved;
    public float distanceAboveCanBeMoved = 1f;



private void Awake()
    {
        
        //deathEffect = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        --lifeTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy.CompareTag("AnchorPillar"))
        {
            if (name.Contains("red"))
            {
                Debug.Log("Red hit a pillar");
            }
            if (name.Contains("blue"))
            {
                Debug.Log("Blue hit a pillar");
            }
        }
        else
        {
            if (name.Contains("Blue")) { Debug.Log("Blue hit an object"); }
            else { Debug.Log("Red hit an object"); }
            //StartCoroutine(DestroyOnCollision());
        }
        Destroy(gameObject);
        Debug.Log("GameObject destroyed");
    }
    /*
    IEnumerator DestroyOnCollision()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        gameObject.GetComponent<Light>().intensity = Mathf.Lerp(gameObject.GetComponent<Light>().intensity, 0f, .5f);
        deathEffect.Play();
        yield return new WaitForSeconds(destructionTime);

        Destroy(gameObject);
        Debug.Log("GameObject destroyed");
    }
    */
    
}
