using UnityEngine;

public class cameraSc : MonoBehaviour
{
    public Transform character;
    public Transform mainCamera;
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        mainCamera.transform.position = new Vector3(character.position.x + 1, character.position.y, -10);

    }
}
