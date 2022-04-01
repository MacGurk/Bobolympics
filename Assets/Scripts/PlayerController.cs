using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float slopeCheckDistance;
    [SerializeField]
    private float maxSlopeAngle;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private GameObject parentObject;

    private float xInput;
    private float slopeDownAngle;

    private bool isGrounded;
    private bool isJumping;
    private bool canJump;

    private Vector2 newVelocity;
    private Vector2 newForce;

    private Vector2 slopeNormalPerp;

    private Rigidbody2D rb;

    private Vector2 respawnPoint;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        CheckGround();
        SlopeCheck();
        ApplyMovement();
    }

    private void SlopeCheck()
    {
        Vector2 checkPos = transform.position;

        SlopeCheckVertical(checkPos);
    }


    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, whatIsGround);

        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            Debug.DrawRay(hit.point, slopeNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }
    }
    private void Jump()
    {
        if (canJump)
        {
            canJump = false;
            isJumping = true;
            newForce.Set(0.0f, jumpForce);
            rb.AddForce(newForce, ForceMode2D.Impulse);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (rb.velocity.y <= 0.0f)
        {
            isJumping = false;
        }

        if (isGrounded && !isJumping)
        {
            canJump = true;
        }

    }

    private void ApplyMovement()
    {
        if (isGrounded && !isJumping)
        {
            newVelocity.Set(movementSpeed * slopeNormalPerp.x * -xInput, movementSpeed * slopeNormalPerp.y * -xInput);
            rb.AddForce(newVelocity, ForceMode2D.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    public void Respawn()
    {
        rb.angularVelocity = 0.0f;
        newVelocity.Set(0.0f, 0.0f);
        rb.velocity = newVelocity;
        transform.rotation = Quaternion.identity; 
        transform.position = respawnPoint;
    }
}
