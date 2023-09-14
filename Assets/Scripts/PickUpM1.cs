using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpM1 : MonoBehaviour
{
    public GameObject M1HoldingObject;
    public GameObject M1Object;   // Reference to the key GameObject.
    public AudioSource src;
    public AudioClip sfx1;
    public TMP_Text text;
    public float maxVisibilityDistance = 10.0f; // Maximum distance at which the chest is considered visible.

    private bool playerInsideTrigger = false;
    void Start()
    {


    }

    void Update()
    {
        // Check if the chest is open and the player presses the "E" key.
        if (playerInsideTrigger && IsM1VisibleToCamera() && Input.GetKeyDown(KeyCode.E) && GameObject.FindWithTag("M1") != null)
        {
            
            Destroy(M1Object);
            src.clip = sfx1;
            src.Play();
            text.text = "M1 Acquired";
            Debug.Log("M1 disappeared");

        }
        // Check if the player is inside the trigger zone and presses the spacebar.


    }

    private void OnTriggerEnter(Collider other)
    {

        playerInsideTrigger = true;

    }

    private void OnTriggerExit(Collider other)
    {

        playerInsideTrigger = false;
       

    }

    private bool IsM1VisibleToCamera()
    {
        

        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogWarning("Main camera is missing.");
            return false;
        }

        // Check if the chest is within the camera's frustum and not too far away.
        Vector3 chestScreenPoint = mainCamera.WorldToScreenPoint(M1HoldingObject.transform.position);
        if (chestScreenPoint.z > 0 &&
            chestScreenPoint.x >= 0 && chestScreenPoint.x <= Screen.width &&
            chestScreenPoint.y >= 0 && chestScreenPoint.y <= Screen.height)
        {
            // Chest is within the camera's view and not too far away.
            float distanceToChest = Vector3.Distance(M1HoldingObject.transform.position, mainCamera.transform.position);
            return distanceToChest <= maxVisibilityDistance;
        }

        return false;
    }
}

