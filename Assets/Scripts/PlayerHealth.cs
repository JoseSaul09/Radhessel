using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public int maxLives = 2;
    private int currentLives;
    private Vector3 initialPosition;
    private CheckpointManager checkpointManager;
    void Start()
    {
        initialPosition = transform.position;
        currentHealth = maxHealth;
        currentLives = maxLives;
        checkpointManager = FindFirstObjectByType<CheckpointManager>();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Salud restante " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        currentLives--;

        if (currentLives > 0)
        {
            RespawnPlayer();
        }
        else
        {
            GameOver();
        }
    }
    void RespawnPlayer()
    {
        currentHealth = maxHealth;

        Vector3 respawnPos = initialPosition;

        if (checkpointManager != null)
        {
            respawnPos = checkpointManager.GetLastCheckpointPosition();
        }

        var rb = GetComponent<Rigidbody>();

        if(rb != null) rb.linearVelocity = Vector3.zero;

        transform.position = respawnPos;

        Debug.Log("Jugador respawneado. Vidas restantes " + currentLives);
    }

    void GameOver()
    {
        SceneManager.LoadScene("Muerte");
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
