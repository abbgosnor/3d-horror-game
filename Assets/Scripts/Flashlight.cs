using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject Flashlightlight;
    private bool FlashlightActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Flashlightlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FlashlightActive == false)
            {
                Flashlightlight.gameObject.SetActive(true);
                FlashlightActive = true;
            }
            else
            {
               Flashlightlight.gameObject.SetActive(false);
                FlashlightActive = false; 
            }
        }
    }
}
