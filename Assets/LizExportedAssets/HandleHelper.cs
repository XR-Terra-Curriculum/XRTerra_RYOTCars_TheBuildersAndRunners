using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class HandleHelper : MonoBehaviour
{

    public Rigidbody ParentRigid;

    /// <summary>
    /// This component is used to pull grab items toward it, and then reset it's position when not being grabbed
    /// </summary>
    public Transform HandleTransform;


    Rigidbody rb;
    bool didRelease = false;
    Collider col;
    bool _isGrab;

    void Start()
    {
        
        
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        // Handle and parent shouldn't collide with each other
        if (col != null && ParentRigid != null && ParentRigid.GetComponent<Collider>() != null)
        {
            Physics.IgnoreCollision(ParentRigid.GetComponent<Collider>(), col, true);
        }
    }

    Vector3 lastAngularVelocity;


    public void IsGrab(bool isGrab)
    {
        _isGrab = isGrab;
        Console.WriteLine("public void IsGrab(bool isGrab) is activated");
       
    }


    void FixedUpdate()
    {

        if (!_isGrab)
        {
            if (!didRelease)
            {
                Console.WriteLine("!_isGrab AND !didRelease");
                //col.enabled = false;
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                transform.localScale = Vector3.one;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                if (ParentRigid)
                {
                    // ParentRigid.velocity = Vector3.zero;
                    // ParentRigid.angularVelocity = Vector3.zero;
                    ParentRigid.angularVelocity = lastAngularVelocity * 20;
                }
                col.enabled = true;
                StartCoroutine(doRelease());

                didRelease = true;
            }
        }
        else
        {
            Console.WriteLine("_isGrab");

            // Object is being held, need to fire release
            didRelease = false;

          

            lastAngularVelocity = rb.angularVelocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Handle Helper Ignores All Collisions
        Physics.IgnoreCollision(col, collision.collider, true);
    }

    IEnumerator doRelease()
    {

        //for(int x = 0; x < 120; x++) {
        //    ParentRigid.angularVelocity = new Vector3(10, 1000f, 50);
        //    yield return new WaitForFixedUpdate();
        //}

        yield return new WaitForSeconds(1f);

        col.enabled = true;
    }
}
