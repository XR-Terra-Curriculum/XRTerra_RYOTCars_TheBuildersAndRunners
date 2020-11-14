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
    public GameObject CarColorChoicesPanel;

 

    void Start()
    {
        CarLights.SetActive(false);
        CarColorChoicesPanel.SetActive(false);

    }

    public void SwitchCarLights()
    {
/*        if (CarLights.activeSelf == true)
        {
            CarLights.SetActive(false);
        }
        else
        {
            CarLights.SetActive(true);
        }*/

        CarLights.SetActive(!CarLights.activeSelf);
    }

    public void ChangeCarExterior(Material ExteriorMat)
    {
        //Console.WriteLine("ChangeCarExterior triggered");
        print("ChangeCarExterior triggered");
        foreach (MeshRenderer renderer in carExteriorRenderers)
        {
            renderer.material = ExteriorMat;
            print("renderer.materials[0] = ExteriorMat;");
        }

        /*
          Renderer[] children;
          children = GetComponentsInChildren<Renderer>();
          foreach (Renderer rend in children)
          {
              var mats = new Material[rend.materials.Length];
              for (var j = 0; j < rend.materials.Length; j++)
              {
                  mats[j] = newMat;
              }
              rend.materials = mats;
          }
              */
    }

    public void ChangeCarInterior(Material InteriorMat)
    {
        foreach(MeshRenderer renderer in carInteriorRenderers)
        {
            renderer.material = InteriorMat;
        }
    }


    public void ShowCarColorChoices(bool show)
    {
        CarColorChoicesPanel.SetActive(show);
    }


}
