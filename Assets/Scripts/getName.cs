using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour
{
    private TMP_Text tmpText;

    void Start()
    {

        // Get the TMP_Text component attached to this GameObject
        tmpText = GetComponent<TMP_Text>();
        if (tmpText != null)
        {
            // Get the name of the parent GameObject
            string parentName = transform.parent != null ? transform.parent.name : "No Parent";
            // Assign the parent's name to the TMP text component
            tmpText.text = parentName;
        }
        else
        {
            Debug.LogWarning("TMP_Text component not found on " + gameObject.name);
        }
    }
}
