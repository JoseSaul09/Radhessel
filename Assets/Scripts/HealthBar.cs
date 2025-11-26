using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraVida : MonoBehaviour
{
    public PlayerHealth player;
    public Image healthBar;
    private void Start()
    {
        if (healthBar) healthBar.type = Image.Type.Filled;
    }

    private void Update()
    {
        if (!player || !healthBar) return;
        healthBar.fillAmount = player.maxHealth > 0f ? player.currentHealth / player.maxHealth : 0f;
    }
}
