using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
}
