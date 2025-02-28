using UnityEngine;

public class goLevel : MonoBehaviour
{

    public void levels(int levelid)
    {
        Application.LoadLevel(levelid);
    }
}
