using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSettingsHelper : MonoBehaviour

{
    public GameObject CarLights;

    void Start()
    {
        CarLights.SetActive(false);
    }

    public void SwitchCarLights()
    {
        if (CarLights.activeSelf == true)
        {
            CarLights.SetActive(false);
        }
        else
        {
            CarLights.SetActive(true);
        }
    }
}
