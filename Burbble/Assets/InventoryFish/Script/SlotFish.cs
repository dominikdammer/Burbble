using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotFish : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DrinkScript draggableItem = dropped.GetComponent<DrinkScript>();
            draggableItem.parentAfterDrag = transform;
        }
    }
}
