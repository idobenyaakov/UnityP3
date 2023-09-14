using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;



public class DoorWithKey : MonoBehaviour
{
    public Animator animator;
    public AudioSource src;
    public AudioClip sfx;
    public TMP_Text Text;

    private void Update()
    {
        if (GameObject.FindWithTag("Key") == null)
        {
            Text.text = "you may enter";
        }
    }
    void OnTriggerEnter(Collider col)
    {
        
        if (GameObject.FindWithTag("Key") == null) 
        {
            animator.SetBool("isOpen", true);
            src.clip = sfx;
            src.Play();
        }
        else 
        {
            Text.text = "You need a key to open this door"; 
        }
        
    }

    void OnTriggerExit(Collider col)
    {
        if (GameObject.FindWithTag("Key") == null)
        {
            animator.SetBool("isOpen", false);
            src.clip = sfx;
            src.Play();
        }
    }
}

