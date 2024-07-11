using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        health -= 1;
        Debug.Log("Health: " + health);
        if (health == 0)
        {
            Debug.Break();
        }

        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, (float) health / maxHealth);
    }
}
