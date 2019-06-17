﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 10f;
    public float gravityFactor = 000.1f;
    public bool gravity = true;
    public ParticleSystem smoke;

    Rigidbody2D rb;
    float screenRatio;
    float orthographicWidth;
    Vector2 playerSize;

    void Start()
    {
        screenRatio = (float)Screen.width / (float)Screen.height;
        orthographicWidth = screenRatio * Camera.main.orthographicSize;
        rb = GetComponent<Rigidbody2D>();
        playerSize.x = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerSize.y = GetComponent<SpriteRenderer>().bounds.extents.y;
        if (gravity)
        {
            AffectByGravity();
        } 
    }

    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        ScreenPlayerLimit();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * speed * Time.fixedDeltaTime);
            smoke.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            smoke.Stop();
        }
    }

    void AffectByGravity()
    {
        rb.gravityScale = gravityFactor;
    }

    void ScreenPlayerLimit()
    {
        Vector2 pos = transform.position;

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float orthographicWidth = screenRatio * Camera.main.orthographicSize;

        bool upLimit = pos.y + playerSize.y > Camera.main.orthographicSize;
        bool downLimit = pos.y - playerSize.y < -Camera.main.orthographicSize;
        bool rightLimit = pos.x + playerSize.x > orthographicWidth;
        bool leftLimit = pos.x - playerSize.x < -orthographicWidth;


        if (upLimit)
        {
            pos.y = Camera.main.orthographicSize - playerSize.y;
        }
        if (downLimit)
        {
            pos.y = -Camera.main.orthographicSize + playerSize.y;
        }

        if (rightLimit)
        {
            pos.x = orthographicWidth - playerSize.x;
        }
        if (leftLimit)
        {
            pos.x = -orthographicWidth + playerSize.x;
        }

        transform.position = pos;
    }
}