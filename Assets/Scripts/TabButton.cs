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
    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
        if (activeColors.Count == 2)
        {
            background.color = activeColors[0];
            tmpText.color = activeColors[1];
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
        if (activeColors.Count == 2)
        {
            background.color = activeColors[0];
            tmpText.color = activeColors[1];
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
        if (inactiveColors.Count == 2)
        {
            background.color = inactiveColors[0];
            tmpText.color = inactiveColors[1];
        }
    }

    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subcribe(this);
    }
    public void Select()
    {
        if (onTabSelected != null)
        {
            onTabSelected.Invoke();
        }
    }
    public void Deselect()
    {
        if (onTabDeselected != null)
        {
            onTabDeselected.Invoke();
        }

    }
}
