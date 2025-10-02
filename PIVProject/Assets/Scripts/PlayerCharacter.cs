using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{
    private CharacterController controller;

    Vector3 move;
    Vector3 moveInput;
    
    [SerializeField]
    private float playerSpeed = 1.0f;

    private float gravityValue = -9.81f;

    private Vector3 playerVelocity;

    [SerializeField]
    private float timeChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && playerVelocity.y > 0)
        {
            playerVelocity.y = 0f;
        }

        float mouseX = Input.GetAxis("Mouse X") * timeChange;
        transform.Rotate(Vector3.up, mouseX);

        playerVelocity.y += gravityValue * Time.deltaTime;

        moveInput = new Vector3(Input.GetAxis("Horizontal"), playerVelocity.y, Input.GetAxis("Vertical"));

        move = transform.TransformDirection(moveInput);

        move *= playerSpeed;

        controller.Move(move * Time.deltaTime);

    }
}
