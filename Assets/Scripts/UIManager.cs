using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    public InventoryManager inventoryManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryPanel();
        }
    }

    void ToggleInventoryPanel()
    {
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);

        if (InventoryPanel.activeSelf)
        {
            inventoryManager.ListItems();
        }
    }
}
