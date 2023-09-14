using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPunch : MonoBehaviour
{
    AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play__sound()
    {
        aud.Play();
    }
}
