using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTeleportHand : MonoBehaviour
{
    public List<XRController> controllersList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (XRController controller in controllersList)
        {
            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool hasInput))
            {
                print(hasInput);
            }
        }
    }
}
