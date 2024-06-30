using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            transform.Rotate(0, 180, 0);
        }
    }
}
