using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CamSettings")]
    public float minAltitudeToZoom = 20f;
    public Vector3 offset;
    public GameObject sCam;

    Player player;

    void Start()
    {
        player = Player.Get();   
    }

    void Update()
    {
        ZoomToPlayer();
    }

    void ZoomToPlayer()
    {
        if (player.altitude <= minAltitudeToZoom)
        {
            sCam.SetActive(true);
        }
        else if (player.altitude > minAltitudeToZoom)
        {
            sCam.SetActive(false);
        }
    }
}
