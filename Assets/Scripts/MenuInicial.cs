using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar()
    {
        Debug.Log("Botón Jugar presionado");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void Salir()
    {
        Debug.Log("Salir...");

        Application.Quit();   // funciona en versión compilada

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // funciona en el editor
#endif
    }
}
