using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HelpInfo : MonoBehaviour
{
    public GameObject HelpMenu;
    private PlayerController playerController;

    private bool isPanelVisible = false;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        HelpMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleHelpMenu();
        }
    }

    void ToggleHelpMenu()
    {
        isPanelVisible = !isPanelVisible;
        HelpMenu.SetActive(isPanelVisible);

        if (isPanelVisible)
        {
            playerController.LockControls();
        }
        else
        {
            playerController.UnlockControls();
        }
    }
}
