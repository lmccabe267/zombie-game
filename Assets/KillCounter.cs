using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public TMP_Text counterText;
    int kills;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showKills();
    }
    private void showKills()
    {
        counterText.text = kills.ToString();
    }
    public void addKill()
    {
        kills++;
    }
}
