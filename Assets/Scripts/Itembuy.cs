using UnityEngine;

public class ItemBuy : MonoBehaviour
{
    public string itemName; 
    public Transform player; 
    public float buyDistance = 5f; 
    public GameObject buyMessage; 

    private bool isPlayerInRange = false;

    void Start()
    {
        buyMessage.SetActive(false); // Hide the message initially
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= buyDistance)
        {
            isPlayerInRange = true;
            buyMessage.SetActive(true); // Show the message
        }
        else
        {
            isPlayerInRange = false;
            buyMessage.SetActive(false); // Hide the message
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            BuyItem();
        }
    }

    void BuyItem()
    {
        // Add the item to the inventory
        Inventory.instance.AddItem(itemName);

        // Hide the buy message
        buyMessage.SetActive(false);

        // Remove the item from the scene
        Destroy(gameObject);
    }
}
