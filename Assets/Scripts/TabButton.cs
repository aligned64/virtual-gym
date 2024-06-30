using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    public Image background;
    public TMP_Text tmpText;
    public UnityEvent onTabSelected;
    public UnityEvent onTabDeselected;
    public List<Color> activeColors;
    public List<Color> inactiveColors;

    private void Awake()
    {
        background = GetComponent<Image>();
        tmpText = GetComponentInChildren<TMP_Text>();
        if (tabGroup != null)
        {
            tabGroup.Subscribe(this);
        }
        SetColors(inactiveColors);
    }

    private void Update()
    {
        if (tabGroup.selectedTab == this && Input.GetKeyDown(KeyCode.Return))
        {
            OnPointerClick(null);
        }
    }

    public void SetColors(List<Color> colors)
    {
        if (colors.Count == 2)
        {
            background.color = colors[0];
            tmpText.color = colors[1];
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    public void Select()
    {
        onTabSelected?.Invoke();
        SetColors(activeColors);
    }

    public void Deselect()
    {
        onTabDeselected?.Invoke();
        SetColors(inactiveColors);
    }
}
