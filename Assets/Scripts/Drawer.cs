using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public Animator drawer;
    public GameObject openText;
    public GameObject closeText;

    private bool inReach;
    private bool drawerisOpen;
    private bool drawerisClosed;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && drawerisClosed)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && drawerisOpen)
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
        drawerisClosed = true;
        drawerisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && drawerisClosed && Input.GetButtonDown("Interact"))
        {
            drawer.SetBool("Open", true);
            drawer.SetBool("Closed", false);
            openText.SetActive(false);
            drawerisOpen = true;
            drawerisClosed = false;
        }

        else if (inReach && drawerisOpen && Input.GetButtonDown("Interact"))
        {
            drawer.SetBool("Open", false);
            drawer.SetBool("Closed", true);
            closeText.SetActive(false);
            drawerisClosed = true;
            drawerisOpen = false;
        }
    }
}
