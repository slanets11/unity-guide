using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4;
    public float jumpForce = 7;

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask layerGrounds;

    private bool isGrounded;
    private float movementX;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Controls input;

    private void Awake()
    {
        input = new Controls();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        input.Player.Move.performed += context => Move(context.ReadValue<float>());        
        input.Player.Move.canceled += context => Move(0);
        input.Player.Jump.performed += context => Jump();
    }

    private void Update()
    {
        rigidbody.velocity = new Vector2(movementX, rigidbody.velocity.y);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, layerGrounds);
        animator.SetBool("isJumping", !isGrounded);
    }

    private void Move(float axis)
    {
        if (axis != 0)
            spriteRenderer.flipX = axis < 0;
        movementX = axis * speed;
        animator.SetBool("isRunning", movementX != 0);
    }

    private void Jump()
    {
        if (isGrounded)
            rigidbody.velocity = new Vector2(movementX, jumpForce);
    }

    private void OnEnable() => input.Enable();

    private void OnDisable() => input.Disable();
}
