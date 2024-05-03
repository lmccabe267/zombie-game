using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public float maxDistance = 10f; // Maximum distance the bullet can travel

    KillCounter killCounterScript;
    Portal portal;

    private Vector2 startPosition; // Starting position of the bullet

    void Start()
    {
        startPosition = transform.position; // Record the starting position of the bullet
        killCounterScript = GameObject.Find("KCO").GetComponent<KillCounter>();
        
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Check if the bullet has reached its maximum distance
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject); // Destroy the bullet if it has
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name + ", " + collision.gameObject.tag);  
        // Optionally, check for a specific collision (e.g., the tilemap)
        if (collision.collider.CompareTag("walls") || collision.collider.CompareTag("ProceedDoor")) // Make sure your tilemap has this tag
        {
            // Logic for the bullet upon hitting the tilemap
            // For example, destroy the bullet:
            Destroy(gameObject);
        }
        

        var zombie = collision.gameObject.GetComponent<Zombie>();
        var bossAldo = collision.gameObject.GetComponent<BossAldo>();
        if (zombie != null)
        {
            if (zombie.health != 0)
            {
                zombie.HitByBullet();
                Destroy(gameObject);
            }
            else if (zombie.health == 0)
            {
                zombie.Die();
                killCounterScript.addKill();
                Destroy(gameObject);
            }
            
        }

        if (bossAldo != null)
        {
            if (bossAldo.health != 0)
            {
                bossAldo.HitByBullet();
                Destroy(gameObject);
            }
            else if (bossAldo.health == 0)
            {
                bossAldo.Die();
                Destroy(gameObject);
                Destroy(bossAldo);
            }
        }
        
        //if (collision.collider.GetComponent("Zombie"))
    }

}
