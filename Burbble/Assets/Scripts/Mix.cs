using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mix : MonoBehaviour, IDropHandler
{
    public GameObject Drink;
    public Transform ParentTransform;
    public SlotIngredient[] SlotIngredient;
    // Aktueller Drink-Wert
    public int currentDrinkValue = 0;
    [SerializeField] private int ingredientCount = 1;
    [SerializeField]
    Slider slider;

    // Methode, um einen Wert zum aktuellen Drink-Wert hinzuzuf�gen
    public void AddToDrinkValue(int value)
    {
        if (ingredientCount < 3)
        {
            currentDrinkValue += value;
            //Debug.Log($"Neuer Drink-Wert: {currentDrinkValue}");
            ingredientCount++;
            slider.value =  ((float)ingredientCount /3) /1f;;
            //Debug.LogError("slider.value" + slider.value);
        }
        else
        {
            //Debug.Log($"Zu viele Zutaten");
        }
    }

    public void ResetDrink()
    {
        currentDrinkValue = 0;
        ingredientCount = 1;
        slider.value = 0;
    }
    public int GetDrinkValue()
    {
        return currentDrinkValue;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Ingredient Ingredient = dropped.GetComponent<Ingredient>();
        AddToDrinkValue(Ingredient.Value);
        if(ParentTransform.childCount == 0)
        {
            GameObject DrinkMix = Instantiate(Drink, ParentTransform);
            DrinkMix.transform.SetParent(ParentTransform);
        }
        
        GetComponentInChildren<DrinkScript>().DrinkValue = currentDrinkValue;
        Destroy(dropped);
        for(int i = 0; i < SlotIngredient.Length; i++)
        {
            SlotIngredient[i].ResetIngredient();
        }
    }
}
