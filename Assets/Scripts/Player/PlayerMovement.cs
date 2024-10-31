using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] private InputActionReference inputMove;
    [SerializeField] private InputActionReference inputJump;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float playerSpeed = 300f;
    [SerializeField] private float rotationSpeed = 200f;

    [Header("Jump parameters")]
    public float rayLength = 0.5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool isGrounded;

    private Animator animator;
    private bool hasDied;

    private Health health;

    private Vector2 v2;

    private void Awake()
    {
        hasDied = false;

        animator = GetComponent<Animator>();
        health = GetComponent<Health>();

        inputMove.action.performed += OnMovement;
        inputMove.action.canceled += OnStop;

        inputJump.action.performed += OnJump;
    }

    private void FixedUpdate()
    {
        if (!this.health.isDead)
        {
            Vector3 movement = transform.forward * v2.y * playerSpeed * Time.fixedDeltaTime;
            rb.AddForce(movement);

            float rotationAmount = v2.x * rotationSpeed * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
            rb.MoveRotation(rb.rotation * deltaRotation);
            
        PlayGroundedAnim();
        PlayAnim();
        }

        //play death anim
        if (this.health.isDead)
        {
            PlayDeathAnim();
        }

        GroundCheck();
    }
    #region Movement Calls

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer);
    }

    private void OnJump(InputAction.CallbackContext value)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnMovement(InputAction.CallbackContext value)
    {
        v2 = value.action.ReadValue<Vector2>().normalized;
    }

    private void OnStop(InputAction.CallbackContext value)
    {
        v2 = Vector2.zero;
        rb.linearVelocity = Vector3.zero;
    }

    #endregion

    #region Animation calls
    private void PlayAnim()
    {
        if (v2.y > 0)
        {
            animator.SetBool("movingFWD", true);
            animator.SetBool("movingBWD", false);
        }
        else if (v2.y < 0)
        {
            animator.SetBool("movingFWD", false);
            animator.SetBool("movingBWD", true);
        }
        else
        {
            animator.SetBool("movingFWD", false);
            animator.SetBool("movingBWD", false);
        }
    }

    private void PlayGroundedAnim()
    {
        if (!isGrounded)
        {
            animator.SetBool("grounded", false);

        } else {

            animator.SetBool("grounded", true);
        }
    }

    private void PlayDeathAnim()
    {
        if (!hasDied)
        {
            animator.SetTrigger("dying");

            hasDied = true;
        }
    }

    #endregion
}
