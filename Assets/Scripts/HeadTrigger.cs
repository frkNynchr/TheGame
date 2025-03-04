using UnityEngine;

public class HeadTrigger : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Destroy(enemy);
        }
    }
}
