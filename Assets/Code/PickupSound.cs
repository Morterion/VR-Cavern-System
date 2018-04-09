using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSound : MonoBehaviour {

    public AudioClip audio;
    private bool picked = false;

    void Start()
    {
        transform.hasChanged = false;
    }

    // Update is called once per frame
    void Update () {
        if(!picked && transform.hasChanged) {
            AudioSource.PlayClipAtPoint(audio, transform.position);
            picked = true;
        }
        
    }
}
