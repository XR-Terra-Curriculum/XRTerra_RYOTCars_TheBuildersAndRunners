using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float rotateSpeed =1f;
    public bool isRotate = true;

    void FixedUpdate()
    {
        if (isRotate)
        {
            this.transform.Rotate(0, rotateSpeed * 0.01f, 0, Space.Self);
        }
    }

    public void RotateSwitch()
    {
        isRotate = !isRotate;
    }
}
