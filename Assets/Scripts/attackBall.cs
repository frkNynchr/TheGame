using UnityEngine;

public class attackBall : MonoBehaviour
{
    public MyCharacter karakter; // Karakterin scripti referans olarak alınacak

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            karakter.Attack(other.gameObject);
        }
    }
}
