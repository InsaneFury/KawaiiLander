using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("CamSettings")]
    public float minAltitudeToZoom = 20f;
    public Vector3 offset;
    public GameObject sCam;
    public float camZoomSpeed = 1;

    Camera secCam;

    Player player;

    void Start()
    {
        player = Player.Get();
        secCam = sCam.GetComponent<Camera>();
    }

    void Update()
    {
        ZoomToPlayer();
        SwitchCamera();
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
    void SwitchCamera()
    {
        if (player.deadFlag)
        {
            float oSize = Mathf.Lerp(sCam.GetComponent<Camera>().orthographicSize, 5, Time.deltaTime * camZoomSpeed);
            secCam.orthographicSize = oSize;
            sCam.transform.position = new Vector3(0,0, sCam.transform.position.z);
        }
    }
}
