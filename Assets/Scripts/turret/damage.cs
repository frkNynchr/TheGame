using UnityEngine;

public class Damage : MonoBehaviour
{
    public turretAı Turret;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "waterBall")
        {
            if (Turret != null)
            {
                Turret.Damage(10);
            }
            Destroy(collision.gameObject);
        }
    }
}
