using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 lastVelocity;
    [SerializeField] float velocityScaler;
    public float velocity;
    public static float timer;
    float timeReset;
    public TMP_Text text;
    Vector2 mousePos;
    Vector2 StartPosition;
    bool ballStart;

    [SerializeField] GameObject horse;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0;
        StartPosition = transform.position;
        ballStart = true;
    }

    private void Update()
    {
        if (timeReset <= 0 && !ballStart) ResetPosition();
        timeReset -= Time.deltaTime;
        timer += Time.deltaTime;
        text.text = (Mathf.Round(timer * 100) / 100f).ToString();
        lastVelocity = rb.velocity;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        velocity = Vector2.Distance(transform.position, mousePos) * velocityScaler;
        if (Input.GetMouseButtonUp(0) && ballStart)
        {
            Vector2 direction = mousePos - (Vector2)rb.transform.position;
            direction.Normalize();
            rb.AddForce(direction * velocity);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0.01f);

    }
    void ResetPosition()
    {
        transform.position = StartPosition;
        ballStart = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball1"))
        {
            transform.position = other.transform.position;
            rb.velocity = new Vector2(0, 0);
            timeReset = 2;
            ballStart = false;
            horse.transform.position = Vector2.Lerp(horse.transform.position, new Vector2(horse.transform.position.x + 0.1f, horse.transform.position.y), 1);
        }
        else if (other.CompareTag("Ball2"))
        {
            transform.position = other.transform.position;
            rb.velocity = new Vector2(0, 0);
            timeReset = 2;
            ballStart = false;
            horse.transform.position = Vector3.Lerp(horse.transform.position, new Vector2(horse.transform.position.x + 0.2f, horse.transform.position.y), 1);
        }
        else if (other.CompareTag("Ball3"))
        {
            transform.position = other.transform.position;
            rb.velocity = new Vector2(0, 0);
            timeReset = 2;
            ballStart = false;
            horse.transform.position = Vector3.Lerp(horse.transform.position, new Vector2(horse.transform.position.x + 0.3f, horse.transform.position.y), 1);
        }
    }
    // void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.CompareTag("Ball1"))
    //     {
    //         if (timeReset <= 0)
    //         {
    //             ResetPosition();
    //             ballStart = f;
    //         }
    //     }
    //     else if (other.CompareTag("Ball2"))
    //     {
    //         if (timeReset <= 0)
    //         {
    //             ResetPosition();
    //             ballStart = true;
    //         }
    //     }
    //     else if (other.CompareTag("Ball3"))
    //     {
    //         if (timeReset <= 0)
    //         {
    //             ResetPosition();
    //             ballStart = true;
    //         };
    //     }
    // }



}
