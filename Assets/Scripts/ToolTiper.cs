using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTiper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TowerInfo _info;
    public static Action<TowerInfo> _onMouseOver;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _onMouseOver?.Invoke(_info);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _onMouseOver?.Invoke(null);
    }
}
