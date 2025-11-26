using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public string dangerTag = "Player";
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(dangerTag))
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Jugador ha muerto!");
        SceneManager.LoadScene("Muerte");
    }
}
