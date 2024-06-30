using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public PanelGroup panelGroup;
    public List<GameObject> objectsToSwap;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && selectedTab != null)
        {
            int currentIndex = tabButtons.IndexOf(selectedTab);
            int nextIndex = (currentIndex + 1) % tabButtons.Count;
            tabButtons[nextIndex].OnPointerClick(null);
        }
    }

    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;
        selectedTab.Select();
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            objectsToSwap[i].SetActive(i == index);
        }
        if (panelGroup != null)
        {
            panelGroup.SetPageIndex(button.transform.GetSiblingIndex());
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
            {
                continue;
            }
            button.background.sprite = tabIdle;
            button.SetColors(button.inactiveColors);
        }
    }
}
