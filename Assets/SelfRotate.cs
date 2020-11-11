using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float rotateSpeed =1f;

    void FixedUpdate()
    {
        this.transform.Rotate(0, rotateSpeed * 0.01f, 0, Space.Self);
    }
}
