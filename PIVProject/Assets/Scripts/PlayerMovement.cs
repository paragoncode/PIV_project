using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 2.5f;
    public float moveSpeed;
    public float sprintSpeed;
    public KeyCode sprintKey = KeyCode.LeftShift;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air
    }

    private void StateHandler()
    {
        if (isGrounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            speed = sprintSpeed;
        }

        else if (isGrounded)
        {
            state = MovementState.walking;
            speed = moveSpeed;
        }

        else
        {
            state = MovementState.air;
        }
    }

    public void increaseSpeed()
    {
        moveSpeed += 0.5f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateHandler();

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
