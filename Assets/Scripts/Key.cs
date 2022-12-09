using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyOnGroud;
    public GameObject keyOB;
    public GameObject pickUpText;
    public bool inReach;
    public static bool canBePicked;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        canBePicked = true;
        pickUpText.SetActive(false);
        keyOB.SetActive(false);
        keyOnGroud.SetActive(true);
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
        if (inReach && canBePicked && Input.GetButtonDown("Interact"))
        {
            keyOB.SetActive(true);
            keyOnGroud.SetActive(false);
            pickUpText.SetActive(false);
        }
    }
}
