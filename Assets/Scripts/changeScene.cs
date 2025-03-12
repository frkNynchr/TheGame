using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void changeScenes()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
