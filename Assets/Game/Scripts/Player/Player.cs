using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonobehaviourSingleton<Player>
{
    [Header("Settings")]
    public float speed = 10f;
    public float gravityFactor = 000.1f;
    public bool gravity = true;
    public ParticleSystem smoke;
    public float fuel = 1000f;
    public float fuelCost = 0.1f;

    [Header("Height Detection Settings")]
    public float rayDistance = 100f;
    public LayerMask layerMask;

    [Header("Landing Settings")]
    public float minHorizontalSpeed = 7f;
    public float minVerticalSpeed = 7f;
    public GameObject deadPlayer;

    [HideInInspector]
    public bool deadFlag = false;
    [HideInInspector]
    public float horizontalSpeed = 0f;
    [HideInInspector]
    public float verticalSpeed = 0f;
    [HideInInspector]
    public float altitude = 0f;

    bool isGrounded = false;
    Rigidbody2D rb;
    float screenRatio;
    float orthographicWidth;
    Vector2 playerSize;
    

    public override void Awake()
    {
        base.Awake();
    }

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
        if (fuel > 0f)
        {
            Move();
        }
        else
        {
            fuel = 0f;
        }
        CheckSpeeds();
        GetAltitude();
    }

    private void LateUpdate()
    {
        ScreenPlayerLimit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        horizontalSpeed = Vector2.Dot(rb.velocity, Vector2.right) * 100f;
        verticalSpeed = Vector2.Dot(rb.velocity, Vector2.up) * 100f;

        Debug.Log(horizontalSpeed + "____" + verticalSpeed);

        bool checkVerticalSpeed = (verticalSpeed > minVerticalSpeed || verticalSpeed < -minVerticalSpeed);
        bool checkHorizontalSpeed = (horizontalSpeed > minHorizontalSpeed || horizontalSpeed < -minHorizontalSpeed);

        if (collision.collider && (checkVerticalSpeed && checkHorizontalSpeed))
        {
            Instantiate(deadPlayer, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
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

            fuel -= fuelCost;
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

    void CheckSpeeds()
    {
        horizontalSpeed = Vector2.Dot(rb.velocity, Vector2.right) * 100f;
        verticalSpeed = Vector2.Dot(rb.velocity, Vector2.up) * 100f;
    }

    void GetAltitude()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, -Vector3.up,rayDistance,layerMask);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y - playerSize.y);
        

        if (hit)
        {
            altitude = Vector2.Distance(pos, hit.point) * 100f;
            if (altitude < 2f)
            {
                altitude = 0f;
            }
        }
    }
}
