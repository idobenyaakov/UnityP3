using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenChestS : MonoBehaviour
{
    public Animator animator;
    public GameObject chestObject; // Reference to the chest GameObject.
    public GameObject keyObject;   // Reference to the key GameObject.
    public AudioSource src;
    public AudioClip sfx,sfx1;
    public TMP_Text text;
    public float maxVisibilityDistance = 10.0f; // Maximum distance at which the chest is considered visible.

    private bool playerInsideTrigger = false;
    private bool isChestOpen = false; // Track whether the chest is open.
    private bool playedSound = false;
    void Start()
    {
        
        
    }

    void Update()
    {
        // Check if the chest is open and the player presses the "E" key.
        if (isChestOpen && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("Key") != null)
        {
            // Make the key disappear.
            Destroy(keyObject);
            src.clip = sfx1;
            src.Play();
            text.text = "Key Acquired";
            Debug.Log("Key disappeared");
        }
        // Check if the player is inside the trigger zone and presses the spacebar.
        if (playerInsideTrigger && Input.GetKey(KeyCode.E))
        {
            // Check if the chest is visible to the camera.
            if (IsChestVisibleToCamera())
            {
                Debug.Log("Chest is visible. Opening the chest");
                animator.SetBool("isOpen", true);
                if (!isChestOpen && !playedSound)
                {
                    src.clip = sfx;
                    src.Play();
                    playedSound = true;
                }
                isChestOpen = true;
                
            }
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        
            playerInsideTrigger = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
       
            playerInsideTrigger = false;
            animator.SetBool("isOpen", false);
        
    }

    private bool IsChestVisibleToCamera()
    {
        if (chestObject == null)
        {
            Debug.LogWarning("Chest object reference is missing.");
            return false;
        }

        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera is missing.");
            return false;
        }

        // Check if the chest is within the camera's frustum and not too far away.
        Vector3 chestScreenPoint = mainCamera.WorldToScreenPoint(chestObject.transform.position);
        if (chestScreenPoint.z > 0 &&
            chestScreenPoint.x >= 0 && chestScreenPoint.x <= Screen.width &&
            chestScreenPoint.y >= 0 && chestScreenPoint.y <= Screen.height)
        {
            // Chest is within the camera's view and not too far away.
            float distanceToChest = Vector3.Distance(chestObject.transform.position, mainCamera.transform.position);
            return distanceToChest <= maxVisibilityDistance;
        }

        return false;
    }
}
