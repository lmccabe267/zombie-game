using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionText : MonoBehaviour
{
    public TMP_Text counterText;
    public float timer = 30f;

    // Start is called before the first frame update
    void Start()
    {
        showText();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 0)
        {
            counterText.enabled = false;
            
        }
        else
        {
            timer--;
        }
    }
    void showText()
    {
        counterText.text = "Mission: Survive and get 100 Kills";
        
    }
}
