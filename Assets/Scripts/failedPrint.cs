using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failedPrint : MonoBehaviour
{
    public GameObject printOB;
    public Printer printer;

    // Start is called before the first frame update
    void Start()
    {
        printOB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (printer.isPrinting == true)
        {
            Debug.Log("yoo");
            StartCoroutine(printKey());
        }
    }

    IEnumerator printKey()
    {
        yield return new WaitForSeconds(1f);
        {
            printOB.SetActive(true);
        }
    }
}
