using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour
{
    public GameObject itemPanel;
    public Text itemNameText;
    public Text itemDescriptionText;
    public Button okButton;
    public Button cancelButton;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        HideItemPanel(); // Hide the panel initially
        okButton.onClick.AddListener(OnOkButtonClick);
        cancelButton.onClick.AddListener(OnCancelButtonClick);
    }

    public void UpdateItemUI(Exercise item)
    {
        if (itemNameText != null && itemDescriptionText != null)
        {
            itemNameText.text = item.itemName;
            itemDescriptionText.text = item.description;
            ShowItemPanel(); // Show the panel when updating the item
        }
        else
        {
            Debug.LogError("UI elements are not assigned in the ExerciseManager script.");
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
        Debug.Log("OK Button Clicked");
        HideItemPanel();
    }

    private void OnCancelButtonClick()
    {
        Debug.Log("Cancel Button Clicked");
        HideItemPanel();
    }
}
