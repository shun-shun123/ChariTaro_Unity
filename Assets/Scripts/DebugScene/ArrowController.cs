using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugScene
{
    public class ArrowController : MonoBehaviour
    {
        float toNorthAngle = 0.0f;

        void Update()
        {
            toNorthAngle = DirectionDetector.GetMagneticHeading();
            transform.rotation = Quaternion.Euler(0, 0, toNorthAngle);
        }
    }
}
