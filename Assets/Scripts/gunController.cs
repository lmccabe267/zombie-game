using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f; // Adjust as needed
    private float nextFireTime = 0f;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Position in the world. It's important to give it some distance from the camera. 
        //If the screen point is calculated right from the exact position of the camera, then it will
        //just return the exact same position as the camera, which is no good.
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        //Angle between mouse and this object
        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);
        Vector3 theScale = Vector3.one;
        theScale.x = 0.75f;
        theScale.z = 0.75f;
        if (angle > 90 || angle < -90)
        {
            theScale.y = -0.75f;
        }
        else
        {
            theScale.y = +0.75f;
        }
        transform.localScale = theScale;
        //Ta daa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        if (canFire && Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            ShootBulletTowardsCursor();
            nextFireTime = Time.time + fireRate; // Update next allowed fire time
        }
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void ShootBulletTowardsCursor()
    {
        // Instantiate the bullet at the player's position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Rotate the bullet to face the mouse direction
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;
        bullet.transform.up = direction;
    }
}
