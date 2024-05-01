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
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = BaseSpeed * (1 + Random.Range(-0.5f, 0.5f));
        _player = FindAnyObjectByType<PlayerController>();
        health = SceneManager.GetActiveScene().buildIndex + 1;
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
        Destroy(gameObject); 
    }
}
