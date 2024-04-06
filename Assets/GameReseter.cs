using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReseter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
