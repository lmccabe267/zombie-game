using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerController _player;
    private float _speed;

    public float BaseSpeed;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = BaseSpeed * (1 + Random.Range(-0.5f, 0.5f));
        _player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (_player != null)
        {
            transform.up = (_player.transform.position - transform.position).normalized;
            _rigidbody.velocity = transform.up * _speed;
        }
    }

    public void Die()
    {
        Destroy(gameObject); 
    }
}
