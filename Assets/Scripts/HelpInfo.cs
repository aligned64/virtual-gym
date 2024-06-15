using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HelpInfo : MonoBehaviour
{
    public GameObject HelpMenu;

    private bool isPanelVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            isPanelVisible = !isPanelVisible;
            HelpMenu.SetActive(isPanelVisible);
        }
    }

}
