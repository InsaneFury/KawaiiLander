using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [Header("WindSettings")]
    public float minTurbulenceForce = -0.5f;
    public float maxTurbulenceForce = -5f;
    public float minAngleTurbulenceForce = -45f;
    public float maxAngleTurbulenceForce = 45f;
    [Tooltip("Less is more")]
    public float turbulenceAmount = 2f;

    bool angleChanged = false;
    AreaEffector2D windZone;

    void Start()
    {
        windZone = GetComponent<AreaEffector2D>();
        InvokeRepeating("Turbulence", 0f, turbulenceAmount);
    }

    void Turbulence()
    {
        windZone.forceMagnitude = Random.Range(minTurbulenceForce, maxTurbulenceForce);
        if (!angleChanged)
        {
            windZone.forceAngle = minAngleTurbulenceForce;
            angleChanged = true;
        }
        else
        {
            windZone.forceAngle = maxAngleTurbulenceForce;
            angleChanged = false;
        }
    }
}
