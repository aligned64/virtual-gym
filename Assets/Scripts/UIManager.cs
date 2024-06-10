using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject itemPanel;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Image itemImage;

    void Start()
    {
        HideItemPanel();
    }

    public void UpdateItemUI(Item item)
    {
        if (itemNameText != null && itemDescriptionText != null && itemImage != null)
        {
            itemNameText.text = item.itemName;
            itemDescriptionText.text = item.description;
            itemImage.sprite = item.itemImage;
            ShowItemPanel();
        }
        else
        {
            Debug.LogError("UI elements are not assigned in the UIManager script.");
        }
    }

    public void ShowItemPanel()
    {
        itemPanel.SetActive(true);
    }

    public void HideItemPanel()
    {
        itemPanel.SetActive(false);
    }
}
