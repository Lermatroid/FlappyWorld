using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector2 mousePos;
    bool jumpPressed = false;

    public float thrust = 0f;
    public float maxSpeed = 10f;
    public Camera cam;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (jumpPressed == false && (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)))
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        Move();
        speedLimiter();
    }

    void Move()
    {
        if (jumpPressed)
        {
            Vector2 lookDirection = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            rb.AddRelativeForce(Vector2.right * thrust, ForceMode2D.Impulse);
            jumpPressed = false;
        }
    }

    void speedLimiter()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DangerZone"))
        {
            Debug.Log("Collided with a danger zone");
        }
        else if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Collided with a projectile");
        }
    }
}
