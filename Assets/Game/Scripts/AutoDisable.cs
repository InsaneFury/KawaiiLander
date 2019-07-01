using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    public void disableObject()
    {
        gameObject.SetActive(false);
    }
}
