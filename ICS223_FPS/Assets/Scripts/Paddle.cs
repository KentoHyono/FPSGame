using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private string vertInputAxis = "VerticalP1";
    private Rigidbody rb;
    private float vertInput = 0f;

    private const float vertMax = 4;
    private const float vertMin = -4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertInput = Input.GetAxisRaw(vertInputAxis);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, vertInput, 0);
        Vector3 newPos = movement + transform.position;
        newPos.y = Mathf.Clamp(newPos.y, vertMin, vertMax);

        rb.MovePosition(newPos);
    }
}
