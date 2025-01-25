using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Game : MonoBehaviour
{
    [SerializeField] public Level[] levels;
    public int[] FishSlotTone;
    public int[] FishSlotToneWithDrink;
    public int[] TargetTone;
    public float delay = 1.0f;

    public bool LevelClear = false;

    public int[] DrinkValue;

    public int LevelIndex;

    Mix mix;

    void Start()
    {
        LoadLevel();
        AddDrinkToFish(FishSlotTone, DrinkValue);
        StartCoroutine(CompareArraysWithDelay(FishSlotTone, TargetTone, delay));
    }

    public void AddDrinkToFish(int[] arr1, int[] arr2)
    {
        for (int i = 0; i < arr1.Length; i++)
        {
           FishSlotToneWithDrink[i] = arr1[i] + arr2[i];
        }

        Debug.Log("Array comparison complete.");
    }

    public void AssigneDrink(int Index)
    {
        DrinkValue[Index] = mix.GetDrinkValue();
        mix.ResetDrink();
    }

    public void LoadLevel()
    {
        for (int i = 0; i < FishSlotTone.Length; i++)
        {
            FishSlotTone[i] = levels[LevelIndex].intFischarten[i];
        }
        for (int i = 0; i < TargetTone.Length; i++)
        {
            TargetTone[i] = levels[LevelIndex].intZieltone[i];
        }
        Debug.Log("New Level loaded");
    }

    public void LoadNextLevel()
    {
        LevelIndex++;
        for (int i = 0; i < FishSlotTone.Length; i++)
        {
            FishSlotTone[i] = levels[LevelIndex].intFischarten[i];
        }
        for (int i = 0; i < TargetTone.Length; i++)
        {
            TargetTone[i] = levels[LevelIndex].intZieltone[i];
        }
        Debug.Log("New Level loaded");
    }
    public void EmptyFishSlots(int[] arr1)
    {
        for (int i = 0; i < arr1.Length; i++)
        {
            FishSlotTone[i] = 0;
        }
        LevelClear = false;
    }

    private IEnumerator CompareArraysWithDelay(int[] FischSlotArray, int[] arr2, float delayTime)
    {
        if (FischSlotArray.Length != arr2.Length)
        {
            Debug.LogError("Arrays have different lengths!");
            yield break;
        }

        bool allMatch = true;

        for (int i = 0; i < FischSlotArray.Length; i++)
        {
            if (FischSlotArray[i] == arr2[i])
            {
                Debug.Log($"Match found at index {i}: {FischSlotArray[i]}");
            }
            else
            {
                allMatch = false;
                Debug.Log($"No match at index {i}: {FischSlotArray[i]} != {arr2[i]}");
            }
            yield return new WaitForSeconds(delayTime);
        }

        if (allMatch)
        {
            LevelClear = true;
            EmptyFishSlots(FishSlotTone);
            Debug.Log("All elements match! Level clear!");
        }
        else
        {
            LevelClear = false;
            Debug.Log("Not all elements match. Level not clear.");
        }

            Debug.Log("Array comparison complete.");
        }
}
