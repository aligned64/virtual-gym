using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
        Debug.Log("Item added: " + item.itemName);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        Debug.Log("Item removed: " + item.itemName);
    }

    public void ListItems()
    {
        if (ItemContent == null)
        {
            Debug.LogError("ItemContent is not assigned.");
            return;
        }

        if (InventoryItem == null)
        {
            Debug.LogError("InventoryItem prefab is not assigned.");
            return;
        }

        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            // Ensure itemName and itemIcon exist and are assigned properly
            var itemName = obj.transform.Find("ItemName")?.GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon")?.GetComponent<Image>();

            if (itemName != null)
            {
                itemName.text = item.itemName;
            }
            else
            {
                Debug.LogError("ItemName Text component not found on " + obj.name);
            }

            if (itemIcon != null)
            {
                itemIcon.sprite = item.icon;
            }
            else
            {
                Debug.LogError("itemIcon Image component not found on " + obj.name);
            }
        }
    }
}
