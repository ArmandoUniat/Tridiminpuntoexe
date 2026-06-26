using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class RigidbodyFPSController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 6f;
    public float jumpForce = 5f;

    [Header("Camera Settings")]
    public Transform playerCamera;
    public float mouseSensitivity = 2f;
    public float upperLookLimit = -80f;
    public float lowerLookLimit = 80f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private float verticalRotation = 0f;
    private bool isGrounded;

    void Start()
    {
        // Get and configure Rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevents the capsule from tipping over

        // Lock and hide the cursor for FPS feel
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleLook();
        HandleJump();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleLook()
    {
        // Get mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera vertically (clamped)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, upperLookLimit, lowerLookLimit);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Rotate the player object horizontally
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        // Get keyboard inputs (WASD / Arrow Keys)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Calculate move direction relative to the direction the player is facing
        Vector3 moveDirection = (transform.forward * moveZ + transform.right * moveX).normalized;

        // Apply movement velocity while preserving current vertical physics velocity (gravity/falling)
        Vector3 targetVelocity = moveDirection * walkSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }

    private void HandleJump()
    {
        // Perform a small sphere check at the feet of the player to see if they are touching ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Check if jump key is pressed and character is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply instant upward force for the jump
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }

    // Optional: Visualizes the ground check radius in the Unity Editor scene view
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}
