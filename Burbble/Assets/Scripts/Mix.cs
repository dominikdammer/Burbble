using UnityEngine;

public class Mix : MonoBehaviour
{
    [SerializeField] public int drinkValue1;
    [SerializeField] public int drinkValue2;
    [SerializeField] public int drinkValue3;
    // Aktueller Drink-Wert
    private int currentDrinkValue = 0;
    private int ingredientCount = 1;

    // Methode, um einen Wert zum aktuellen Drink-Wert hinzuzufügen
    public void AddToDrinkValue(int value)
    {
        if (ingredientCount <= 3)
        {
            currentDrinkValue += value;
            Debug.Log($"Neuer Drink-Wert: {currentDrinkValue}");
            ingredientCount++;
        }
        else
        {
            Debug.Log($"Zu viele Zutaten");
        }
    }

    public void ResetDrink()
    {
        currentDrinkValue = 0;
        ingredientCount = 1;
    }
    public int GetDrinkValue()
    {
        return currentDrinkValue;
    }
}
