using UnityEngine;
using UnityEngine.UI;

public class StartPanelController : MonoBehaviour
{
    public GameObject startPanel;  
    public GameObject gameplayElements; 

    void Start()
    {
        startPanel.SetActive(true);
        gameplayElements.SetActive(false);
    }

    public void ClosePanel()
    {
        startPanel.SetActive(false);
        gameplayElements.SetActive(true);
    }
}
