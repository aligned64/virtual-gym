using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject itemPanel;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Image itemImage;
    public Button okButton;
    public Button cancelButton;
    private PlayerController playerController;
    private HealthInfo healthInfo;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        healthInfo = FindObjectOfType<HealthInfo>();

        HideItemPanel(); // Hide the panel initially
        okButton.onClick.AddListener(OnOkButtonClick);
        cancelButton.onClick.AddListener(OnCancelButtonClick);
    }

    public void UpdateItemUI(Item item)
    {
        if (itemNameText != null && itemDescriptionText != null && itemImage != null)
        {
            itemNameText.text = item.itemName;
            itemDescriptionText.text = item.description;
            itemImage.sprite = item.itemImage;
            ShowItemPanel(); // Show the panel when updating the item
        }
        else
        {
            Debug.LogError("UI elements are not assigned in the UIManager script.");
        }
    }

    public void ShowItemPanel()
    {
        itemPanel.SetActive(true);
        playerController.LockControls();
    }

    public void HideItemPanel()
    {
        itemPanel.SetActive(false);
        playerController.UnlockControls();
    }

    private void OnOkButtonClick()
    {
        HideItemPanel();
        healthInfo.Change();
    }

    private void OnCancelButtonClick()
    {
        HideItemPanel();
    }
}
