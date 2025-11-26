using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public WeaponHitbox hitbox;      // arrastra el objeto del hitbox aquí
    public float attackDuration = 0.2f; // tiempo que el hitbox está activo (segundos)
    public float attackCooldown = 0.4f; // tiempo entre ataques (segundos)
    private bool canAttack = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canAttack) // botón por defecto: mouse izquierdo / Ctrl
        {
            StartCoroutine(DoAttack());
        }
    }

    IEnumerator DoAttack()
    {
        canAttack = false;
        // activar ventana de daño
        hitbox.active = true;

        // si prefieres, también puedes activar visualmente el collider:
        // hitbox.gameObject.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        hitbox.active = false;

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
