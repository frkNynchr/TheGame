using UnityEngine;

public class attackBall : MonoBehaviour
{
    public MyCharacter karakter; // Karakterin scripti referans olarak alınacak

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("turret"))
        {
            Debug.Log("Düşman tespit edildi! Ateş ediliyor: " + other.tag);
            karakter.Attack(other.gameObject);
        }
        else
        {
            Debug.Log("Düşman tespit edilmedi!" + other.tag);
        }
    }
}
