using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        if (musicPlayer == null)
        {
            musicPlayer = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
