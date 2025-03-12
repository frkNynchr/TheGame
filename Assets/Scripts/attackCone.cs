using UnityEngine;

public class attackCone : MonoBehaviour
{
    public turretAı turretAI;
    public bool isLeft = false;
    void Awake()
    {
        turretAI = gameObject.GetComponentInParent<turretAı>();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isLeft)
            {
                turretAI.Attack(false);
            }
            else
            {
                turretAI.Attack(true);
            }
        }
    }
}