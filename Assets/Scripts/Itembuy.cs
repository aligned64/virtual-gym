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
        buyMessage.SetActive(false); 
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= buyDistance)
        {
            isPlayerInRange = true;
            buyMessage.SetActive(true); 
        }
        else
        {
            isPlayerInRange = false;
            buyMessage.SetActive(false); 
        }

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            BuyItem();
        }
    }

    void BuyItem()
    {
        
        Inventory.instance.AddItem(itemName);

        
        buyMessage.SetActive(true);

        
        Destroy(gameObject);
    }
}
