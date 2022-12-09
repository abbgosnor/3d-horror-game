using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    public Animator camAnim;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
            camAnim.SetTrigger("run");
            }
            else
            {
            camAnim.SetTrigger("walk");
            }
        }
        else
        {
            camAnim.SetTrigger("idle");
        }
    }
}