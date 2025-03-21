using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyCharacter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed, maxSpeed, jumpPower, h, ballSpeed, ballLife, ballCount;
    public bool isFloor, dJump, isAndorid, leftB, rightB, jumpB, isPaused;
    Rigidbody2D weight, ballRb;
    Animator anim;
    public int health, maxHealth;
    public int coin = 0;
    public GameObject[] healths;
    public GameObject[] balls;
    public Text coinCount;
    public AudioClip[] sounds;
    public GameObject androidPanel;
    public GameObject enemy;
    public GameObject waterBall;
    public Transform atesNoktasi;

    void Start()
    {
        anim = GetComponent<Animator>();
        weight = GetComponent<Rigidbody2D>();
        health = maxHealth;
        ballCount = ballLife;
        healthSys();

        StartCoroutine(RegenerateBall());
    }

    void Update()
    {
        coinCount.text = "" + coin;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isFloor)
            {
                Jump();
                dJump = true;
            }
            else
            {
                if (dJump)
                {
                    Jump();
                    dJump = false;
                }
            }
        }

        if (health <= 0)
        {
            death();
        }
        if (isAndorid)
        {
            androidPanel.SetActive(true);
        }
        else
        {
            androidPanel.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        anim.SetFloat("speed", Mathf.Abs(h));
        anim.SetBool("isFloor", isFloor);
        if (isAndorid)
        {
            if (leftB)
            {
                transform.localScale = new Vector2(-0.5f, 0.5f);
                h = 1;
                transform.Translate(h * speed * Time.deltaTime, 0, 0);

            }
            if (rightB)
            {
                transform.localScale = new Vector2(0.5f, 0.5f);
                h = -1;
                transform.Translate(h * speed * Time.deltaTime, 0, 0);
            }
            if (!leftB && !rightB)
            {
                h = 0;
            }
        }
        else
        {
            if (!isPaused) // Eğer oyun duraklatılmadıysa hareket et
            {
                h = Input.GetAxis("Horizontal");
                //weight.AddForce(Vector3.right * h * speed);
                transform.Translate(-h * speed * Time.deltaTime, 0, 0);
                anim.SetFloat("speed", Mathf.Abs(h));
                anim.SetBool("isFloor", isFloor);

                if (h > 0.01f)
                {
                    transform.localScale = new Vector2(0.5f, 0.5f);
                }
                if (h < -0.01f)
                {
                    transform.localScale = new Vector2(-0.5f, 0.5f);
                }
                if (weight.linearVelocity.x > maxSpeed)
                {
                    weight.linearVelocity = new Vector2(maxSpeed, weight.linearVelocity.y);
                }
                if (weight.linearVelocity.x < -maxSpeed)
                {
                    weight.linearVelocity = new Vector2(-maxSpeed, weight.linearVelocity.y);
                }
            }
            else
            {
                weight.linearVelocity = Vector2.zero; // Durdur
            }

        }
    }

    void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            health -= 1;
            weight.AddForce(Vector2.up * jumpPower);
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Stand", 0.5f);
            healthSys();
        }
        if (collision.gameObject.tag == "deathLine")
        {
            health -= 1;
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Stand", 0.5f);
            healthSys();
            transform.position = new Vector3(0.3f, 1.9f, 0f);
        }
        if (collision.gameObject.tag == "enemy")
        {
            health -= 1;
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Stand", 0.5f);
            healthSys();
            Jump();
        }

    }
    void healthSys()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            healths[i].SetActive(false);
        }
        for (int i = 0; i < health; i++)
        {
            healths[i].SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(sounds[1]);
            coin += 1;

        }
        if (collision.gameObject.tag == "plusHealth")
        {
            if (health != maxHealth)
            {
                Destroy(collision.gameObject);
                health += 1;
                healthSys();
                GetComponent<SpriteRenderer>().color = Color.green;
                Invoke("Stand", 0.5f);

            }
        }
        if (collision.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("LevelSelect");
        }
        if (collision.gameObject.tag == "headTrig")
        {
            Jump();
            Destroy(enemy);
        }
        if (collision.gameObject.tag == "bullet")
        {
            health -= 1;
            GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("Stand", 0.5f);
            healthSys();
            Destroy(collision.gameObject);
        }
    }

    void Stand()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

    }
    public void Jump()
    {
        weight.AddForce(Vector2.up * jumpPower);
    }
    public void Pause()
    {
        isPaused = !isPaused;
    }
    public void Attack(GameObject turrets)
    {
        if (ballCount > 0)
        {
            Vector2 direction = (turrets.transform.position - transform.position).normalized;
            GameObject bullet = Instantiate(waterBall, atesNoktasi.position, atesNoktasi.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            rb.linearVelocity = direction * ballSpeed;
            ballCount -= 1;
            ballSys();
        }

    }

    public void ballSys()
    {
        for (int i = 0; i < ballLife; i++)
        {
            balls[i].SetActive(false);
        }
        for (int i = 0; i < ballCount; i++)
        {
            balls[i].SetActive(true);
        }
    }
    IEnumerator RegenerateBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (ballCount == 0)
            {
                ballCount += 3;
                ballSys();
                GetComponent<SpriteRenderer>().color = Color.blue;
                Invoke("Stand", 0.5f);
            }
        }
    }
}