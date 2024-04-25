using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public RectTransform rectTransformHand;
    
    public static bool PointerIsOnSlot = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("On drop");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = rectTransformHand.anchoredPosition;
        }
    }

    public void PointerOnSlot()
    {
        PointerIsOnSlot = true;
    }

    public void PointerOutSlot()
    {
        PointerIsOnSlot = false;
    }
}

