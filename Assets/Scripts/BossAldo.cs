
using UnityEngine;

public class BossAldo : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerController _player;
    private float _speed;
    public float BaseSpeed;
    public float health = 10;
    public float maxHealth = 10;
    public GameObject BloodPrefab;
    
    [SerializeField] FloatingHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = BaseSpeed * (1 + Random.Range(-0.5f, 0.5f));
        _player = FindAnyObjectByType<PlayerController>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();

    }

    // Update is called once per frame
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

        healthBar.UpdateHealthBar(health, maxHealth);
    }
    public void Die()
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
