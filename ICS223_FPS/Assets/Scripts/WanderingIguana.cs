using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class WanderingIguana : MonoBehaviour
{
    private float iguanaSpeed = 3.0f;
    private float obstacleRange = 9.0f;

    private Animator anim;

    private float turn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = iguanaSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine if we're headed for an obstacle
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.5f, out hit))
        {
            // If there an obstacle in the way that is close enough to warrant a turn
            if (hit.distance < obstacleRange)
            {
                // if out run value if not set to 0, we need to decide on a left or right turn
                if (Mathf.Approximately(turn, 0.0f))
                {
                    // Flip a coin
                    turn = Random.Range(0, 2) == 0 ? -0.75f : 0.75f;
                }

                // turn quickly and forward slowly
                Move(turn, 0.1f);
            } 
            else // on obstacle within the range
            {
                float forwardSpeed = Random.Range(0.05f, 1.0f);
                turn = 0.0f;

                // do not turn and forward randomly
                Move(turn, forwardSpeed);
            }
        } 
    }

    private void Move(float turn, float forward)
    {
        float dampTime = 0.2f;
        if (anim != null)
        {
            anim.SetFloat("Turn", turn, dampTime, Time.deltaTime);
            anim.SetFloat("Forward", forward, dampTime, Time.deltaTime);
        }
    }
}
