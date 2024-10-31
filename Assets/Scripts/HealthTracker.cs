using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class HealthTracker : MonoBehaviour
{

    public Player player;
    public Collider2D col;
    public int StartingHealth = 3;

    private int currentHealth;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        
        ResetHealth();
    }    

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            //character dies
            isDead = true;
            player.CharacterDies();
        }
    }

    public void ResetHealth()
    {
        isDead = false;
        currentHealth = StartingHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
    }

    public void SetStartingHealth(int health)
    {
        StartingHealth = health;
        ResetHealth();
    }
}
