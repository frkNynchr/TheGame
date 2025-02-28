using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyCharacter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed, maxSpeed, jumpPower, h;
    public bool isFloor, dJump, isAndorid, leftB, rightB, jumpB;
    Rigidbody2D weight;
    Animator anim;
    public int health, maxHealth, star, coin;
    public GameObject[] healths;
    public GameObject[] stars;
    public Text coinCount;
    public AudioClip[] sounds;
    public GameObject androidPanel;

    void Start()
    {
        anim = GetComponent<Animator>();
        weight = GetComponent<Rigidbody2D>();
        health = maxHealth;
        star = 0;
        coin = 0;
        healthSys();
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = "" + coin;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);

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
    }

    void death()
    {
        Application.LoadLevel(Application.loadedLevel);
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
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(sounds[0]);
            starSys();
        }
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
            Application.LoadLevel("MainMenu");
        }
    }

    void starSys()
    {
        star += 1;
        for (int i = 0; i < star; i++)
        {
            stars[i].SetActive(true);
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
}
