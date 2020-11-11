using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour

{
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GameController")
        {
            Console.WriteLine("controller onCollisionEnter");
        }

    }


    /*
    public void HandleIsGrab(bool IsGrab)
    {
        if (IsGrab)
        {
           Console.WriteLine("handle is grabbed");
        }
        else
        {
           Console.WriteLine("handle is not grabbed");

        }
    }
    */



}
