using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MouseLook : ActiveDuringGameplay
{
    // enum to set avlues by name instead of number.
    // makes code more readable!
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }

    // public class-scope variable so it shows up in Inspector
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitibityHoriz = 7.0f;
    public float sensitibityVert = 7.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float rotationX = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            // horizontal rotation here
            float deltaHoriz = Input.GetAxis("Mouse X") * sensitibityHoriz;
            transform.Rotate(Vector3.up * deltaHoriz);
        }
        else if (axes == RotationAxes.MouseY)
        {
            // vertical rotation here
            rotationX -= Input.GetAxis("Mouse Y") * sensitibityVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            transform.localEulerAngles = new Vector3(rotationX, 0, 0);
        }
        else
        {
            // both horizontal and vertical rotation here
            // vertical rotation here
            rotationX -= Input.GetAxis("Mouse Y") * sensitibityVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            float deltaHoriz = Input.GetAxis("Mouse X") * sensitibityHoriz;
            float rotationY = transform.localEulerAngles.y + deltaHoriz;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
