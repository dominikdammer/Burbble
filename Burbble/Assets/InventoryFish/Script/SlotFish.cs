using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotFish : MonoBehaviour, IDropHandler
{
    public SlotIngredient[] SlotIngredient;
    public Mix mix;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DrinkScript draggableItem = dropped.GetComponent<DrinkScript>();

        if (draggableItem == null)
        {
            Debug.LogError("Dropped object does not have a DrinkScript attached.");
            return;
        }
        if(transform.childCount == 0)
        {
            draggableItem.parentAfterDrag = transform;
            draggableItem.CanDrag = false;
        }
        else{
            Transform existingChild = transform.GetChild(0);
            Destroy(existingChild.gameObject);
            draggableItem.parentAfterDrag = transform;
            draggableItem.CanDrag = false;
        }

        for(int i = 0; i < SlotIngredient.Length; i++)
        {
            SlotIngredient[i].ResetIngredient();
        }
        mix.ResetDrink();
    }
}
