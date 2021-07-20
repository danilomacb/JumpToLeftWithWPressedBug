using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private bool canJump = true;

    private Rigidbody2D playerRigidbody2D;

    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if(horizontalMovement > 0 || horizontalMovement < 0)
        {
            playerRigidbody2D.velocity = new Vector2(horizontalMovement * speed, playerRigidbody2D.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;

            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x, jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
}
