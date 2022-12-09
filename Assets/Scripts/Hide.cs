using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Transform teleportTarget;
    public Transform deTeleportTarget;
    public GameObject thePlayer;
    public GameObject hideText;
    public UnHide unhide;

    private bool inReach;

    void Start() 
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (UnHide.hidden == false)
        {
            hideText.SetActive(true);
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        hideText.SetActive(false);
        inReach = false;
    }

    void Update() 
    {
        if (Input.GetButtonDown("Interact") && inReach && UnHide.hidden == false)
        {
            thePlayer.transform.position = teleportTarget.transform.position;
            thePlayer.GetComponent<playerMovement>().walkspeed = 0f;
            thePlayer.GetComponent<playerMovement>().runSpeed = 0f;
            hideText.SetActive(false);
            UnHide.hidden = true;
        }
    }
}
