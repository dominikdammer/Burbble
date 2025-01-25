using UnityEngine;

public class Mix : MonoBehaviour
{
    [SerializeField] public int drinkValue1;
    [SerializeField] public int drinkValue2;
    [SerializeField] public int drinkValue3;
    // Aktueller Drink-Wert
    private int currentDrinkValue = 0;

    // Methode, um einen Wert zum aktuellen Drink-Wert hinzuzufügen
    public void AddToDrinkValue(int value)
    {
        currentDrinkValue += value;
        Debug.Log($"Neuer Drink-Wert: {currentDrinkValue}");
    }

    // Methode, um den aktuellen Drink-Wert abzurufen
    public int GetCurrentDrinkValue()
    {
        return currentDrinkValue;
    }
}
