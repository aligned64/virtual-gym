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
        SetColors(activeColors);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
        SetColors(inactiveColors);
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
