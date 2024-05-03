using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToBoss : MonoBehaviour
{
    
    public int zombiesKilled;
    public int zombieThreshold = 100;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        zombiesKilled = GameObject.Find("KCO").GetComponent<KillCounter>().kills;
        if(zombiesKilled >= zombieThreshold)
        {
            gameObject.SetActive(false);
        }
        //adding comment
    }
}
