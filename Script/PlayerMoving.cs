using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoving : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public float walkSpeed = 2f;
    public float rotateSpeed = 100f;
    public float gravity = 9.81f;
    public float jumpHeight = 2f;

    private Vector3 velocity;
    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        isGrounded = characterController.isGrounded;

        // Optional - only if you're using isGrounded in Animator
        // animator.SetBool("isGrounded", isGrounded);

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space))
        {
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
                animator.SetTrigger("Jump");
        }

        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        bool isRunning = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);
        animator.SetBool("Run", isRunning);

        float currentSpeed = isRunning ? walkSpeed * 2f : walkSpeed;

        Vector3 move = (vAxis * transform.forward) + (hAxis * transform.right);
        move = Vector3.ClampMagnitude(move, 1f);
        characterController.Move(move * currentSpeed * Time.deltaTime);

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);

        // Gravity and vertical movement
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        float movementAmount = new Vector2(hAxis, vAxis).magnitude;
        animator.SetFloat("walk", movementAmount);
    }
}
