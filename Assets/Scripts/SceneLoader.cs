using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private bool isPanelVisible = false;
    public GameObject QuitButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPanelVisible = !isPanelVisible;
            QuitButton.SetActive(isPanelVisible);
            if (isPanelVisible)
            {
                QuitGame();
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}