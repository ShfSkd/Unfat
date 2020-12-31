using UnityEngine;
using UnityEngine.SceneManagement;

// Make Start button go to Level 1
public class Menu : MonoBehaviour
{
    public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
