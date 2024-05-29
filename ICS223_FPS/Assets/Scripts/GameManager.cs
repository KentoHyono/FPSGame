using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    private float courtMinX = -11;
    private float courtMaxX = 11;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    [SerializeField] UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        ball.Reset();
        ball.Launch(GetRandomBallDirection(), ball.speed);
    }

    private Vector3 GetRandomBallDirection()
    {
        float x = 1;
        float y = 1;

        if (Random.Range(0.0f, 1.0f) > 0.5)
        {
            x = -1;
        }

        if (Random.Range(0.0f, 1.0f) > 0.5)
        {
            y = -1;
        }

        return new Vector3(x, y, 0);
    }

    private void restart()
    {
        ui.UpdateScore(scoreP1, scoreP2);
        ball.Reset();
        ball.Launch(GetRandomBallDirection(), ball.speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x > courtMaxX)
        {
            scoreP1 += 1;
            restart();
        }
        if (ball.transform.position.x < courtMinX)
        {
            scoreP2 += 1;
            restart();
        }
    }
}
