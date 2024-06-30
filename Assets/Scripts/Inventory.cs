using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private List<string> items = new List<string>();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log(itemName + " added to inventory.");
    }

    public void PrintInventory()
    {
        Debug.Log("Inventory: " + string.Join(", ", items));
    }
}
