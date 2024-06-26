using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrientationController : MonoBehaviour
{

    float horizontal;
    public Animator animator;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        animator.SetFloat("Speed2", Mathf.Abs(vertical));


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

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        bool faceDirection = (mousePosition.x > transform.position.x);

        if (faceDirection)
        {
            transform.localScale = new Vector3(-10f, 10f, 10f);

        }
        else
        {
            transform.localScale = new Vector3(10f, 10f, 10f); 
        }
    }
}
