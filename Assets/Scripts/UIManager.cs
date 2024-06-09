using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIManager : MonoBehaviour
{
    public Text itemNameText;
    public Text itemDescriptionText;
    public Image itemImage;

    public void UpdateItemUI(Item item)
    {
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.description;
        itemImage.sprite = item.itemImage;
    }
}
