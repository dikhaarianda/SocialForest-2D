using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D rb;
    private Animator animator;
    private float dirX;
    private bool isFacingRight;

    [Header("Check Ground")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * walkSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void FixedUpdate() {
        if (dirX < 0)
        {
            transform.eulerAngles = Vector2.up * 180;
        }
        else if (dirX > 0)
        {
            transform.eulerAngles = Vector2.zero;
        }
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if(rb.velocity.x != 0f && isGrounded)
        {
            animator.SetTrigger("isRun");
        }
        else if(dirX == 0 && isGrounded)
        {
            animator.SetTrigger("isIdle");
        }

        if(rb.velocity.y > 1f)
        {
            animator.SetTrigger("isJump");
        }
        else if(rb.velocity.y < -1f)
        {
            animator.SetTrigger("isFall");
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheck.position, boxSize);
    }
}