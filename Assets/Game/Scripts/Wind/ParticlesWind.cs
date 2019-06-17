using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesWind : MonoBehaviour
{
    public GameObject particleWind;

    void Start()
    {
        particleWind.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActiveWindZone();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisableWindZone();
        }
    }

    void ActiveWindZone()
    {
        particleWind.SetActive(true);
    }

    void DisableWindZone()
    {
        particleWind.SetActive(false);
    }
}
