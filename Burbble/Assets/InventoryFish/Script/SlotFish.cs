using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotFish : MonoBehaviour, IDropHandler
{
    //public SlotIngredient[] SlotIngredient;
    public Mix mix;
    public Game game;
    public int IndexFish;
    private Image DrinkImage;

    [SerializeField] DrinkColorChanger drinkColorChanger;

    public void Update()
    {
        if(game.LevelClear)
        {
            drinkColorChanger.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DrinkScript draggableItem = dropped.GetComponent<DrinkScript>();
        drinkColorChanger.ChangeColor(draggableItem.DrinkValue);

        

        DrinkImage = dropped.GetComponent<Image>();
        var tempColor = DrinkImage.color;
        tempColor.a = 0f;
        DrinkImage.color = tempColor;
        
        game.AssigneDrink(IndexFish);

        if (draggableItem == null)
        {
            //Debug.LogError("Dropped object does not have a DrinkScript attached.");
            return;
        }
        if(transform.childCount == 0)
        {
            draggableItem.parentAfterDrag = transform;
            draggableItem.CanDrag = false;
        }
        else{
            //Debug.Log("destroy drink");
            Transform existingChild = transform.GetChild(0);
            existingChild.gameObject.GetComponent<DrinkScript>().ResetDrink();
            //Destroy(existingChild.gameObject);
            draggableItem.parentAfterDrag = transform;
            draggableItem.CanDrag = false;
        }
        game.AddDrinkToFish();
        mix.ResetDrink();
    }
}
