using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugScene
{
    public class ArrowController : MonoBehaviour
    {
        float toNorthAngle = 0.0f;
        DirectionDetector directionDetector;

        void Start()
        {
            directionDetector = GameObject.Find("DirectionDetector").GetComponent<DirectionDetector>();
        }

        // Update is called once per frame
        void Update()
        {
            toNorthAngle = directionDetector.GetMagneticHeading();
            transform.rotation = Quaternion.Euler(0, 0, toNorthAngle);
        }
    }
}
