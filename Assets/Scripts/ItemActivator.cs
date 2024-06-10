using UnityEngine;
public class ItemActivator : MonoBehaviour
{
    public Item item;
    private UIManager uiManager;
    private bool isPlayerNearby = false;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed. Activating item: " + item.itemName);
            ActivateItem();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone for item: " + item.itemName);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger zone for item: " + item.itemName);
            isPlayerNearby = false;
            uiManager.HideItemPanel(); // Hide the panel when the player exits the trigger zone
        }
    }

    void ActivateItem()
    {
        uiManager.UpdateItemUI(item);
    }

    // Optional: Draw Gizmos to visualize the trigger area
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider>().bounds.size);
    }
}
