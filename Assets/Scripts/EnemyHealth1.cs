using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("UI de Vida")]
    public Slider healthSlider;   // <- referencia al Slider del CanvasEnemy

    public GameObject deathEffect;
    public System.Action onDeath;

    void Awake()
    {
        currentHealth = maxHealth;

        // Inicializar el slider si está asignado
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // Actualizar slider
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathEffect != null)
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        onDeath?.Invoke(); 
        Destroy(gameObject);
    }
}
