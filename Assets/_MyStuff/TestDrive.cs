using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TestDrive : MonoBehaviour
{
    public GameObject car;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("XRI_Right_Trigger") != 0)
        {
            speed = Input.GetAxis("XRI_Right_Trigger");
            car.transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetAxis("XRI_Left_Trigger") != 0)
        {
            speed = Input.GetAxis("XRI_Left_Trigger");
            car.transform.Translate(Vector3.back * speed);
        }

    }
}
