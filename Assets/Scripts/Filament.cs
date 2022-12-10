using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filament : MonoBehaviour
{
    public GameObject filamentInvOB;
    public GameObject filamentOBonGround;
    public GameObject pickUpText;
    public bool inReach;
    public static bool canBePicked;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        canBePicked = true;
        pickUpText.SetActive(false);
        filamentInvOB.SetActive(false);
        filamentOBonGround.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && canBePicked)
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact") && canBePicked)
        {
            filamentInvOB.SetActive(true);
            filamentOBonGround.SetActive(false);
            pickUpText.SetActive(false);
        }
    }
}
