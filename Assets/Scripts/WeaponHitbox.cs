using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    // daño por golpe
    public float damage = 25f;

    // si el owner puede dañar (lo controlará PlayerAttack)
    [HideInInspector] public bool active = false;

    void Awake()
    {
        // asegurarse que sea trigger
        Collider c = GetComponent<Collider>();
        if (c != null)
            c.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!active) return; // solo cuando está activa la ventana de ataque

        // buscar componente EnemyHealth en el objeto golpeado o en sus padres
        EnemyHealth eh = other.GetComponent<EnemyHealth>();
        if (eh == null)
            eh = other.GetComponentInParent<EnemyHealth>();

        if (eh != null)
        {
            eh.TakeDamage(damage);

            // Si quieres evitar golpear varias veces al mismo enemigo en la misma animación,
            // podrías mantener una lista temporal de ya-golpeados. (opcional)
        }
    }
}
