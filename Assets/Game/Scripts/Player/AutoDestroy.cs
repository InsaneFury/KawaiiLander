using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time = 5f;
    void Start()
    {
        Invoke("Clean", time);
    }
    void Clean()
    {
        Destroy(gameObject);
    }
}
