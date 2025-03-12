using UnityEngine;
using UnityEngine.SceneManagement;

public class goLevel : MonoBehaviour
{

    public void levels(int levelid)
    {
        SceneManager.LoadScene(levelid);
    }
}
