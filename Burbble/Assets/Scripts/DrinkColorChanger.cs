using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DrinkColorChanger : MonoBehaviour
{

    [SerializeField]
    Color[] DrinkColors;
    [SerializeField]
    [ReadOnly]
    Color pickedColor;

    SpriteRenderer sprite;
    void Start()
    {
        sprite= GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    public void EnableDrinkContent()
    {
        sprite.enabled = true;
    }

    public void ChangeColor()
    {
        if (DrinkColors != null)
        {
            pickedColor = DrinkColors[Mathf.Abs((Random.Range(0, DrinkColors.Length)))];

            sprite.color = new Color(pickedColor.r, pickedColor.g, pickedColor.b,1);

        }
    }
}
