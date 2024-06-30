using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    public List<GameObject> panels;

    public void SetPageIndex(int index)
    {
        if (panels == null || panels.Count == 0)
        {
            Debug.LogWarning("PanelGroup: No panels to switch between.");
            return;
        }

        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(i == index);
        }
    }
}
