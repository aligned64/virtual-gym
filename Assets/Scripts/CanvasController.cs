
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    // Reference to the Canvas component
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Canvas component attached to this GameObject
        canvas = GetComponent<Canvas>();

        // Ensure the canvas is not visible by default
        if (canvas != null)
        {
            canvas.enabled = false;
        }
        else
        {
            Debug.LogWarning("Canvas component not found on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'F' key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the canvas visibility
            if (canvas != null)
            {
                canvas.enabled = !canvas.enabled;
            }
        }
    }
}
