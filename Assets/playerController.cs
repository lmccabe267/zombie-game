using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    public Transform target;
    public GameObject BloodPrefab;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //// Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var zombie = other.collider.GetComponent<Zombie>();
        if (zombie != null )
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        FindObjectOfType<TMP_Text>().enabled = true;
        Destroy(gameObject);
    }
}
