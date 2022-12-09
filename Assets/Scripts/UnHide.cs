using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnHide : MonoBehaviour
{
    public Transform deTeleportTarget;
    public GameObject thePlayer;
    public GameObject hideStopText;
    public static bool hidden;

    private bool inReach;

    void Start()
    {
        inReach = false;
        hidden = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (hidden == true)
        {
            hideStopText.SetActive(true);
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        hideStopText.SetActive(false);
        inReach = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach && hidden == true)
            {
                thePlayer.GetComponent<playerMovement>().walkspeed = 6f;
                thePlayer.GetComponent<playerMovement>().runSpeed = 12f;
                hideStopText.SetActive(false);
                thePlayer.transform.position = deTeleportTarget.transform.position;
                hidden = false; 
            }
    }
}
