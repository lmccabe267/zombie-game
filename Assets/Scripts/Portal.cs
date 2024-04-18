using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int zombieThreshold = 100;
    public GameObject portal;
    public Renderer myRenderer;
    private bool portalActivated = false;
    public int zombiesKilled;
    
    // Start is called before the first frame update
    void Start()
    {
        myRenderer.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (portalActivated == false)
        {

            zombiesKilled = GameObject.Find("KCO").GetComponent<KillCounter>().kills;
            if (zombiesKilled >= zombieThreshold)
            {
                ActivatePortal();
            }
        }
        
    }
    void ActivatePortal()
    {
        portalActivated = true;
        myRenderer.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Portal Triggered");
        if(portalActivated && other.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
