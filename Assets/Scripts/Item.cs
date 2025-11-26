using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public bool isConsumable = false;
    public virtual bool Use(GameObject user)
    {
        Debug.Log($"Recogiste: {itemName}");
        return true;
    }
}
