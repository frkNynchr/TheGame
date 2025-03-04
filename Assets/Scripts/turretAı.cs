using System.Threading.Tasks;
using UnityEngine;

public class turretAı : MonoBehaviour
{
    public int curHealth, maxHealth;
    public float distance, wakeRange, shootInterval, bulletTimer;
    public float bulletSpeed = 100;

    public bool awake = false;
    public bool lookingRight = true;
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        anim.SetBool("isAwake", awake);
        anim.SetBool("lookRight", lookingRight);

        rangeCheck();
        if (target.transform.position.x > transform.position.x)
        {
            lookingRight = false;
        }
        if (target.transform.position.x < transform.position.x)
        {
            lookingRight = true;
        }
    }
    public void rangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < wakeRange)
        {
            awake = true;
        }
        if (distance > wakeRange)
        {
            awake = false;
        }
    }
    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
                bulletTimer = 0;
            }
            if (attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
                bulletTimer = 0;
            }
        }
    }
}
