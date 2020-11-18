using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CarSettingsHelper : MonoBehaviour

{
    public GameObject CarLights;
    public Renderer[] carExteriorRenderers;
    public Renderer[] carInteriorRenderers;
    public Renderer[] carWheelRenderers;
    public GameObject CarColorChoicesPanel;
    public GameObject CarWheelChoicesPanel;




    void Start()
    {
        CarLights.SetActive(false);
        CarColorChoicesPanel.SetActive(false);
        CarWheelChoicesPanel.SetActive(false);
    }

    public void SwitchCarLights()
    {

        CarLights.SetActive(!CarLights.activeSelf);
    }

    public void ChangeCarExterior(Material ExteriorMat)
    {
        foreach (MeshRenderer renderer in carExteriorRenderers)
        {
            renderer.material = ExteriorMat;
        }
    }

    public void ChangeCarInterior(Material InteriorMat)
    {
        foreach(MeshRenderer renderer in carInteriorRenderers)
        {
            renderer.material = InteriorMat;
        }
    }

    public void ChangeCarWheel(Material WheelMat)
    {
        foreach (MeshRenderer renderer in carWheelRenderers)
        {
            renderer.material = WheelMat;
        }
    }


    public void ShowCarColorChoices(bool show)
    {
        CarColorChoicesPanel.SetActive(show);
    }

    public void ShowCarWheelChoices(bool show)
    {
        CarWheelChoicesPanel.SetActive(show);
    }


}
