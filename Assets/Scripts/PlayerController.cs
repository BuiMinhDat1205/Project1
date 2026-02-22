using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float normalSpeed;
    public float jumpForce = 12f;
    public float climbSpeed = 4f;
    public float rollSpeed = 8f;

    [Header("Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Combat")]
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float arrowForce = 15f;

    private Rigidbody2D rb;
    private Animator anim;

    private float moveInput;
    private float climbInput;

    private bool isGrounded;
    private bool isClimbing;
    private bool isNearLadder;
    private bool isRolling;
    private bool isFacingRight = true;

    private float defaultGravity;

    void Start()
    {
        normalSpeed = speed;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        defaultGravity = rb.gravityScale;
    }

    void Update()
    {
        if (isRolling) return;

        Move();
        Jump();
        Climb();
        Shoot();
        Roll();

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        CheckGround();
    }

    // ================= MOVE =================

    void Move()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (!isClimbing)
        {
            rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        }

        if (moveInput > 0 && !isFacingRight)
            Flip();

        if (moveInput < 0 && isFacingRight)
            Flip();
    }

    // ================= JUMP =================

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetTrigger("jump");
        }
    }

    // ================= CLIMB =================

    void Climb()
    {
        climbInput = Input.GetAxis("Vertical");

        if (isNearLadder)
        {
            if (Mathf.Abs(climbInput) > 0)
            {
                isClimbing = true;
                rb.gravityScale = 0;

                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    climbInput * climbSpeed
                );
            }
            else if (isClimbing)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            }
        }
        else
        {
            isClimbing = false;
            rb.gravityScale = defaultGravity;
        }
    }

    // ================= SHOOT =================

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && arrowPrefab != null)
        {
            anim.SetTrigger("bow");

            GameObject arrow = Instantiate(
                arrowPrefab,
                firePoint.position,
                Quaternion.identity
            );

            Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();

            float direction = isFacingRight ? 1 : -1;

            arrowRb.linearVelocity =
                new Vector2(direction * arrowForce, 0);
        }
    }

    // ================= ROLL =================

    void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            StartCoroutine(RollCoroutine());
        }
    }

    IEnumerator RollCoroutine()
    {
        isRolling = true;

        anim.SetTrigger("roll");

        float direction = isFacingRight ? 1 : -1;

        rb.linearVelocity =
            new Vector2(direction * rollSpeed, rb.linearVelocity.y);

        yield return new WaitForSeconds(0.5f);

        isRolling = false;
    }

    // ================= LADDER DETECTION =================

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isNearLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isNearLadder = false;
            isClimbing = false;
            rb.gravityScale = defaultGravity;
        }
    }

    // ================= GROUND CHECK =================

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    // ================= ANIMATION =================

    void UpdateAnimation()
    {
        anim.SetFloat("speed", Mathf.Abs(moveInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isClimbing", isClimbing);
        anim.SetFloat("verticalSpeed", rb.linearVelocity.y);
    }

    // ================= FLIP =================

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }

    // ================= HIT =================

    public void Hit()
    {
        anim.SetTrigger("hit");
    }
}