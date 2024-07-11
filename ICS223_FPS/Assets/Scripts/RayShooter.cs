using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : ActiveDuringGameplay
{
    // [SerializeField] private int aimSize = 16;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        // Hide the mouse cursor
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            // Checks if it hits something
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                // If it hits enemy
                if (target != null)
                {
                    target.ReactToHit();
                } else
                {
                    // visually indicate where there was a hit
                    StartCoroutine(CreateTempSphereIndicator(hit.point));
                }
            }
        }
    }

    // Coroutine that creates temporary shpere at hit position and destroy it
    private IEnumerator CreateTempSphereIndicator(Vector3 hitPosition)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.position = hitPosition;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
