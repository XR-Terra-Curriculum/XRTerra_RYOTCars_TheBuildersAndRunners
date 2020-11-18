using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class LineToTransform : MonoBehaviour {
        public Transform ConnectTo;
        LineRenderer line;

        void Start() {
            line = GetComponent<LineRenderer>();
            if(line) {
                line.useWorldSpace = false;
            }
        }
        void LateUpdate() {
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, transform.InverseTransformPoint(ConnectTo.position));
        }
    }


