using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, Health, GameReset
{
    private float health;
    public float maxEnemyHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxEnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxEnemyHealth);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Spawner.EnemyKilled();
            Destroy(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
