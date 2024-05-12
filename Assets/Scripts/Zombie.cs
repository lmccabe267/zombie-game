using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerController _player;
    private float _speed;
    public float health; 
    public float BaseSpeed;
    public GameObject BloodPrefab;
    public string gravestoneTag = "graves";
    private Collider2D zombieCollider;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = BaseSpeed * (1 + Random.Range(-0.25f, 0.5f));
        _player = FindAnyObjectByType<PlayerController>();
        health = SceneManager.GetActiveScene().buildIndex + 1;
        zombieCollider = GetComponent<CircleCollider2D>();
        GameObject[] gravestones = GameObject.FindGameObjectsWithTag(gravestoneTag);

        foreach (var gravestone in gravestones)
        {
            Collider2D gravestoneCollider = gravestone.GetComponent<BoxCollider2D>();
            if (gravestoneCollider != null)
            {
                Physics2D.IgnoreCollision(zombieCollider, gravestoneCollider);
            }
        }
    }

    void Update()
    {
        if (_player != null)
        {
            transform.up = (_player.transform.position - transform.position).normalized;
            _rigidbody.velocity = transform.up * _speed;
        }
    }
    public void HitByBullet()
    {
        health -= 1;
    }

    public void Die()
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        GetComponent<PowerUpStore>().InstantiatePowerUpDrop(transform.position);
        Destroy(gameObject); 
    }
}
