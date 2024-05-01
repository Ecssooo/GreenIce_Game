using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropItem : MonoBehaviour, IDropHandler
{
    public RectTransform rectTransformHand;

    public Image imageSlot;
    public SpriteItem spriteItem;
    
    public static bool PointerIsOnSlot = false;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(GetComponent<RectTransform>().transform);  
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(180, -330, 2);
            InventoryManager.objectInHand = eventData.pointerDrag;
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

