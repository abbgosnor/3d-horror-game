using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public Animator printer;
    public GameObject filamentOB;
    public GameObject filamentInvOB;
    public GameObject filamentOBonGround;
    public GameObject printText;
    public GameObject noFilamentText;
    public GameObject refillFilamentText;
    public GameObject alreadyPrintingText;
    public GameObject printedKeyOB;

    private bool inReach;
    public bool filament;
    private bool isPrinting;
    private bool donePrinting;

    void OnTriggerEnter(Collider other)
    {
        //om du kollar på printern, den inte redan printar och du har filament
        if (other.gameObject.tag == "Reach" && !isPrinting && filament && !donePrinting)
        {
            inReach = true;
            printText.SetActive(true);
        }
        //om du kollar på printern, den inte redan har filament och du inte har filament på dig
        if (other.gameObject.tag == "Reach" && !isPrinting && !filament && !filamentOB.activeInHierarchy && !filamentInvOB.activeInHierarchy)
        {
            inReach = true;
            noFilamentText.SetActive(true);
        }
        //om du kollar på printern och den redan printar
        if (other.gameObject.tag == "Reach" && isPrinting)
        {
            inReach = true;
            alreadyPrintingText.SetActive(true);
        }
        //om du har objektet filament men ej har suttit in det
        if (other.gameObject.tag == "Reach" && !filamentOB.activeInHierarchy && filamentInvOB.activeInHierarchy)
        {
            inReach = true;
            refillFilamentText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //om du kollar bort från printern
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            printText.SetActive(false);
            noFilamentText.SetActive(false);
            refillFilamentText.SetActive(false);
            alreadyPrintingText.SetActive(false);
        }
    }

    // Start is called before the first frame update
    //stänger av all text vid start
    void Start()
    {
        inReach = false;
        printText.SetActive(false);
        noFilamentText.SetActive(false);
        refillFilamentText.SetActive(false);
        filamentInvOB.SetActive(false);
        filamentOB.SetActive(false);
        donePrinting = false;
        printedKeyOB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //testar om du har suttit in filamentet eller ej
        if (!filamentOB.activeInHierarchy)
        {
            filament = false;
        }

        else 
        {
            filament = true;
        }

        if (inReach && filamentOB.activeInHierarchy && !isPrinting && !donePrinting && Input.GetButtonDown("Interact"))
        {
            isPrinting = true;
            printer.SetBool("printing", true);
            Key.canBePicked = false;
            StartCoroutine(printKey());
            printText.SetActive(false);
        }

        if (inReach && !filamentOB.activeInHierarchy && !isPrinting && filamentInvOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            filamentOB.SetActive(true);
            filamentInvOB.SetActive(false);
            refillFilamentText.SetActive(false);
            printText.SetActive(true);
            printedKeyOB.SetActive(false);
        }
    }

    IEnumerator printKey()
    {
        yield return new WaitForSeconds(1f);
        {
            printedKeyOB.SetActive(true);
        }
        yield return new WaitForSeconds(20f);
        {
            printer.SetBool("printing", false);
            isPrinting = false;
            donePrinting = true;
            Key.canBePicked = true;
        }
    }
}
