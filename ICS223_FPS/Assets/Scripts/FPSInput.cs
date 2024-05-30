using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    [SerializeField] private float speed = 9.0f;
    [SerializeField] private CharacterController cc;
    private float gravity = -9.8f;
    private float horizInput = 0f;
    private float vertInput = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);

        // Clamp mognitude to limit diagnoal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        // Take speed into acconut 
        movement *= speed;
        // Add gravity
        movement.y = gravity;
        // Make processor independent
        movement *= Time.deltaTime;
        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);

        cc.Move(movement);
    }
}
