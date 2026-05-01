using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jump = 12f;

    private bool isGround;
    private Rigidbody2D rb;

    public AudioSource audioSource;
    public AudioClip jumpSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            audioSource.PlayOneShot(jumpSound);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            isGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            if (rb.linearVelocity.y <= 0)
            {
                isGround = true;
            }
        }
    }
}
