using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Prevent Rigidbody from being removed from this class (Player)
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    private Rigidbody rb;
    private float horiz;
    private float vert;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        // transform.Translate(movement);
    }

    private void FixedUpdate()
    {
        // Normally x will be horizontal, and z will be verticall when camera is facing z, but in this case
        // camera is facing the direction of -X, so needed to modify movement.
        Vector3 movement = new Vector3(-1 * vert, 0, horiz) * speed * Time.deltaTime * 100;
        // rb.AddForce(movement);
        rb.velocity = movement;
    }
}
