using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDoor : MonoBehaviour
{

    public Animator door;
    public GameObject openText;
    public GameObject closeText;

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && doorisClosed && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            doorisOpen = true;
            doorisClosed = false;
        }

        else if (inReach && doorisOpen && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            closeText.SetActive(false);
            doorisClosed = true;
            doorisOpen = false;
        }
    }
}
