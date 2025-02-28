using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform character;
    void Start()
    {
        character = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Update()
    {
        transform.position = new Vector3(character.position.x, character.position.y, -10);
    }
}
