using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private Canvas Canvas;
    private PlayerController playerController;

    void Start()
    {
        Canvas = GetComponent<Canvas>();
        // Ensure the exercisesPanel is not visible by default
        if (Canvas != null)
        {
            Canvas.enabled = false;
        }
        else
        {
            Debug.LogWarning("Canvas component not found on " + gameObject.name);
        }

        // Find the PlayerController in the scene
        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

    void Update()
    {
        // Check if the 'F' key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the exercisesPanel visibility
            if (Canvas != null)
            {
                Canvas.enabled = !Canvas.enabled;
                if (Canvas.enabled)
                {
                    playerController.LockControls();
                }
                else
                {
                    playerController.UnlockControls();
                }
            }
        }
    }
}
