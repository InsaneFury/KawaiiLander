using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 resetPos;

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    public void RestartFollowCamera()
    {
        transform.position = resetPos;
        gameObject.GetComponent<Camera>().orthographicSize = 2f;
    }
}
