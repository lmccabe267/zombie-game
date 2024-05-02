using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrientationController : MonoBehaviour
{

    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        Vector3 theScale = Vector3.one;
        theScale.y = 10f;
        theScale.z = 10f;
        if (horizontal < 0)
        {
            theScale.x = +10f;
        }
        else
        {
            theScale.x = -10f;
        }
        transform.localScale = theScale;

        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-coordinate is 0

        // Determine if the mouse is to the left or right of the player
        bool mouseToRight = (mousePosition.x > transform.position.x);

        // Flip the player sprite based on mouse position
        if (mouseToRight)
        {
            transform.localScale = new Vector3(-10f, 10f, 10f); // Face left

        }
        else
        {
            transform.localScale = new Vector3(10f, 10f, 10f); // Face right
        }
    }
}
