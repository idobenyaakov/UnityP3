using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    
    public Animator animator;
    public AudioSource src;
    public AudioClip sfx;

    void OnTriggerEnter(Collider col)
    {
        
        animator.SetBool("isOpen", true);
        src.clip = sfx;
        src.Play();
    }

    void OnTriggerExit(Collider col)
    {
        
         animator.SetBool("isOpen", false);
        src.clip = sfx;
        src.Play();

    }
}
