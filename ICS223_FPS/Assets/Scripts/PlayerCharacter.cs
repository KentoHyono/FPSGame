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

    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }

    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }

    public void Hit()
    {
        health -= 1;
        Debug.Log("Health: " + health);
        if (health <= 0)
        {
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }

        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, (float) health / maxHealth);
    }

    private void OnPickupHealth(int healthAdded)
    {
        health += healthAdded;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, (float)health / maxHealth);
    } 
} 
