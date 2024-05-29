using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0f;
    [SerializeField] Rigidbody rb;

    void Start()
    {
    }

    public void Launch(Vector3 movement, float speed)
    {
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
