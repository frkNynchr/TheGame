using UnityEngine;

public class projectile : MonoBehaviour
{
    public Rigidbody2D ballRb;
    public float speed;
    public float ballLife;
    public float ballCount;
    void Start()
    {
        ballCount = ballLife;
    }

    // Update is called once per frame
    void Update()
    {
        ballCount -= Time.deltaTime;
        if (ballCount <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        ballRb.linearVelocity = new Vector2(speed, ballRb.linearVelocity.y);
    }
}
