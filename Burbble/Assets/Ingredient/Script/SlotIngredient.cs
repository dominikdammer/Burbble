using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotIngredient : MonoBehaviour
{
    public GameObject Ingredient;
    public Transform ParentTransform;
    public void ResetIngredient()
    {
        if(ParentTransform.childCount == 0)
        {
            GameObject DrinkMix = Instantiate(Ingredient, ParentTransform);
            DrinkMix.transform.SetParent(ParentTransform);
        }
    }
}
