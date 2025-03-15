using System.Collections;
using UnityEngine;

public class attackBall : MonoBehaviour
{
    public MyCharacter karakter;
    private bool isAttacking = false; // Aynı anda birden fazla coroutine çalışmasını önler

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("turret") && !isAttacking)
        {
            StartCoroutine(AttackRoutine(other.gameObject));
        }
    }

    IEnumerator AttackRoutine(GameObject turret)
    {
        isAttacking = true;
        while (true)
        {
            karakter.Attack(turret);
            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("turret"))
        {
            StopAllCoroutines(); // Eğer turret alanından çıkarsa saldırıyı durdur
            isAttacking = false;
        }
    }
}
