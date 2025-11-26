using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallBack;

    public List<Item> items = new List<Item>(); 
    public int space = 5;

    // Contador de monedas
    public int coinsCollected = 0;
    public int coinsNeeded = 5; // ← Cambia si quieres más

    private void Awake()
    {
        if (inventory != null)
        {
            Debug.LogWarning("Más de un inventario detectado");
            return;
        }
        inventory = this;
    }

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Inventario lleno"); 
            return false;
        }

        items.Add(item);

        // ---------------------------
        //       DETECTAR COIN
        // ---------------------------
        if (item.itemName == "Coin")  // ← AQUI ya está el nombre correcto
        {
            coinsCollected++;
            Debug.Log("Coins recogidas: " + coinsCollected);

            if (coinsCollected >= coinsNeeded)
            {
                Debug.Log("Has recogido todas las Coins. Cargando siguiente nivel...");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (onInventoryChangedCallBack != null)
        {
            onInventoryChangedCallBack.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item); 
        if (onInventoryChangedCallBack != null)
        {
            onInventoryChangedCallBack.Invoke();
        }
    }
}
