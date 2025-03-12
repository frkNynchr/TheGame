using UnityEngine;

public class rangeSc : MonoBehaviour
{

    public Transform character;
    public Transform attRange;
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
        attRange = GameObject.FindGameObjectWithTag("range").transform;
    }

    void Update()
    {
        attRange.transform.position = new Vector3(character.position.x, character.position.y);
    }
}
