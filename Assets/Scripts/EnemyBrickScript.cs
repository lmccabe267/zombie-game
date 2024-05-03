using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrickScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 38);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var bullet = collision.collider.GetComponent<Bullet>();
        if (collision.collider.CompareTag("walls") || collision.collider.CompareTag("zombies") || collision.collider.CompareTag("ProceedDoor"))
        {
            Destroy(gameObject);
        }
        else if(collision.collider.CompareTag("bullets"))
        {
            Physics2D.IgnoreLayerCollision(9,13);
        }

        Destroy(gameObject);
        
        
    }
}
