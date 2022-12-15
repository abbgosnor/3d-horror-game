using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenPrinter : MonoBehaviour
{
    public Animator printer;
    public GameObject filamentOB;
    public GameObject filamentInvOB;
    public GameObject filamentOBonGround;
    public GameObject printText;
    public GameObject noFilamentText;
    public GameObject refillFilamentText;
    public GameObject printedFailOB;

    private bool inReach;
    public bool filament;
    public bool isPrinting;
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
        //om du har objektet filament men ej har suttit in det
        if (other.gameObject.tag == "Reach" && !filamentOB.activeInHierarchy && filamentInvOB.activeInHierarchy && !donePrinting)
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
        printedFailOB.SetActive(false);
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
            Filament.canBePicked = false;
            StartCoroutine(printKey());
            printText.SetActive(false);
        }

        if (inReach && !filamentOB.activeInHierarchy && !isPrinting && filamentInvOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            filamentOB.SetActive(true);
            filamentInvOB.SetActive(false);
            refillFilamentText.SetActive(false);
            if (!donePrinting)
            { 
                printText.SetActive(true);
            }
            printedFailOB.SetActive(false);
        }
    }

    IEnumerator printKey()
    {
        yield return new WaitForSeconds(1f);
        {
            printedFailOB.SetActive(true);
        }
        yield return new WaitForSeconds(20f);
        {
            printer.SetBool("printing", false);
            isPrinting = false;
            donePrinting = true;
            Filament.canBePicked = true;
        }
    }
}
