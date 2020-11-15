using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class AutoSelectHandedness : MonoBehaviour
{

    public GameObject RightSelect;
    public GameObject LeftSelect;
    public GameObject RightTeleport;
    public GameObject LeftTeleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchType(RightSelect, RightTeleport);
        SwitchType(LeftSelect, LeftTeleport);
    }

    public void SwitchType(GameObject selector, GameObject teleporter)
    {
        XRController controller = selector.GetComponent<XRController>();
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 vector2))
        {
            if (vector2.magnitude >= 0.2f)
            {
                print("Magnitude cutoff surpassed");
                selector.SetActive(false);
                teleporter.SetActive(true);
            }
            else
            {
                selector.SetActive(true);
                teleporter.SetActive(false);
            }
        }
    }
    public void Test()
    {
        print("This is a test, yay!");
    }
}
