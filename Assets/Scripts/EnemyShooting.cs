using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject brick;
    public Transform brickPos;
    public GameObject player;
    private PlayerController _player;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }

        
    }
    void shoot()
    {
        Instantiate(brick, brickPos.position, Quaternion.identity);
    }
}
