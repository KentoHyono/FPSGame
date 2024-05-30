using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 6f;
    [SerializeField] private float sensitivityHoriz = 9.0f;
    [SerializeField] private CharacterController cc;

    // Used for gravity
    private float yVelocity = 0.0f;
    private float gravity = -9.81f; // downward pull of gravity
    private float yVelocityWhenGrounded = -4.0f;

    // Used for jump
    private float jumpHeight = 3.0f; // jump height in units
    private float jumpTime = 0.5f; // jump air time in seconds
    private float initialJumpVelocity = 0f; 

    void Start()
    {
        cc = GetComponent<CharacterController>();
        HandleJump();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void HandleJump()
    {
        // Jump
        float timeToApex = jumpTime / 2.0f;
        // Gravity required to support this jump
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);
        // Use gravity to calculate initial jump velocity
        initialJumpVelocity = (2 * jumpHeight) / timeToApex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horiz, 0, vert);

        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movement *= speed;
        // local to world
        movement = transform.TransformDirection(movement);

        // velocity of a falling object after elapsed time
        // v= gt
        // calculate downword velocity
        yVelocity += gravity * Time.deltaTime;
        // if on the grond and falling (not headed upwards)
        if (cc.isGrounded && yVelocity < 0.0)
        {
            yVelocity = yVelocityWhenGrounded;
        }

        // jump
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            yVelocity = initialJumpVelocity;
        }

        movement.y = yVelocity;

        movement *= Time.deltaTime;

        cc.Move(movement);

        // Rotation
        float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
        transform.Rotate(Vector3.up * deltaHoriz);
    }

}
