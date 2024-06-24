using UnityEngine;

public class ExerciseActivator : MonoBehaviour
{
    public Exercise item;
    private ExerciseManager exerciseManager;
    private bool isPlayerNearby = false;

    void Start()
    {
        // Find the ExerciseManager in the scene
        exerciseManager = FindObjectOfType<ExerciseManager>();
    }

    void Update()
    {
        // Check if player is nearby and the E key is pressed
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !exerciseManager.itemPanel.activeSelf)
        {
            ActivateItem();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has the Player tag
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the other collider has the Player tag
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            exerciseManager.HideItemPanel();
        }
    }

    void ActivateItem()
    {
        // Call the UpdateItemUI method on the exerciseManager instance
        exerciseManager.UpdateItemUI(item);
    }
}
