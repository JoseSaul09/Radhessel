using UnityEngine;

public class NormalEF : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    public Transform chaseTarget;
    public bool chaseMode = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip alertSound;
    public AudioClip walkingSound;
    public AudioClip attackSound;
    public AudioClip deathSound;

    private void Start()
    {
        // Obtiene el audio source del enemigo
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (chaseMode && chaseTarget != null)
        {
            // -------- MOVIMIENTO --------
            Vector3 dir = (chaseTarget.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;

            // -------- ROTACIÓN HACIA EL JUGADOR (solo en Y) --------
            Vector3 lookPos = chaseTarget.position - transform.position;
            lookPos.y = 0f;

            if (lookPos != Vector3.zero)
            {
                Quaternion rot = Quaternion.LookRotation(lookPos);

                // Corrección si tu modelo mira hacia atrás (muy común)
                rot *= Quaternion.Euler(0, 180, 0);

                transform.rotation = rot;
            }
        }
    }

    // Detecta que el jugador entra al rango
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chaseTarget = other.transform;
            chaseMode = true;

            // Sonido de alerta al detectar al jugador
            if (alertSound != null)
                audioSource.PlayOneShot(alertSound);

            // Sonido de caminar
            if (walkingSound != null)
                audioSource.PlayOneShot(walkingSound);
        }
    }

    // Detecta que el jugador sale del rango
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chaseMode = false;
            chaseTarget = null;
        }
    }

    // Llamar desde tu animación o tu script de ataque
    public void PlayAttackSound()
    {
        if (attackSound != null)
            audioSource.PlayOneShot(attackSound);
    }

    // Llamar desde tu script de muerte
    public void PlayDeathSound()
    {
        if (deathSound != null)
            audioSource.PlayOneShot(deathSound);
    }
}
