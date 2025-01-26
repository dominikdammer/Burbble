using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

public class Game : MonoBehaviour
{
    [SerializeField] public Level[] levels;
    public int[] FishSlotTone;
    public int[] FishFinalSound;
    public int[] TargetTone;
    public GameObject[] FishSlots;
    [SerializeField] public Sprite[] FishSprites;
    [SerializeField] public AudioClip[] burps;
    public float delay = 1.0f;

    public bool[] gotDrink;

    public bool LevelClear = false;

    public int[] DrinkValue;

    public int LevelIndex;

    public Mix mix;

    AudioSource burpSound;

    private float StartPitch;
    [SerializeField] private float WrongPitch = 1f;
    

    void Start()
    {
        LoadLevel();
        burpSound = GetComponent<AudioSource>();
        StartPitch = burpSound.pitch;
        StartCoroutine(CompareArraysWithDelay(FishFinalSound, TargetTone, delay));
    }


    public void AddDrinkToFish()
    {
        for (int i = 0; i < FishSlotTone.Length; i++)
        {
           FishFinalSound[i] = FishSlotTone[i] + DrinkValue[i];
        }

        Debug.Log("Array comparison complete.");
    }

    public void AssigneDrink(int Index)
    {
        DrinkValue[Index] = mix.GetDrinkValue();
        mix.ResetDrink();
        gotDrink[Index] = true;
    }

    public void LoadLevel()
    {
        for (int i = 0; i < FishSlotTone.Length; i++)
        {
            FishSlotTone[i] = levels[LevelIndex].intFischarten[i];
            if(FishSlotTone[i] == 1)
            {
                FishSlots[i].GetComponent<SpriteRenderer>().sprite = FishSprites[0];

            }
            if(FishSlotTone[i] == 2)
            {
                FishSlots[i].GetComponent<SpriteRenderer>().sprite = FishSprites[1];

            }
            if(FishSlotTone[i] == 3)
            {
                FishSlots[i].GetComponent<SpriteRenderer>().sprite = FishSprites[2];

            }
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
        LoadLevel();
    }
    public void EmptyFishSlots(int[] arr1)
    {
        for (int i = 0; i < arr1.Length; i++)
        {
            FishSlotTone[i] = 0;
        }
        LevelClear = false;
    }

    private IEnumerator CompareArraysWithDelay(int[] FishSlot, int[] arr2, float delayTime)
    {
        while (true)
        {
            if (FishFinalSound.Length != arr2.Length)
            {
                Debug.LogError("Arrays have different lengths!");
                yield break;
            }

            
            bool allMatch = true;



            for (int i = 0; i < FishSlot.Length; i++)
            {
                if (gotDrink[i])
                {
                    switch (FishFinalSound[i])
                    {
                        case 1:
                            burpSound.clip = burps[0];
                            break;
                        case 2:
                            burpSound.clip = burps[1];
                            break;
                        case 3:
                            burpSound.clip = burps[2];
                            break;
                        case 4:
                            burpSound.clip = burps[3];
                            break;
                        case 5:
                            burpSound.clip = burps[4];
                            break;

                        default:
                            burpSound.clip = burps[0];
                            break;
                    }
                    if (FishFinalSound[i] == arr2[i])
                    {
                        burpSound.pitch = StartPitch;
                    }
                    else
                    {
                        burpSound.pitch = WrongPitch;
                        StartCoroutine(ChangePitchOverTime(burpSound, WrongPitch, StartPitch, delayTime));
                    }
                    burpSound.Play();
                    
                }
                if (gotDrink[i])
                {
                    // FishSlots[i].GetComponent<FloatingObject>().amplitude = .5f;
                    FishSlots[i].GetComponent<FloatingObject>().SetAmplitude(0.5f);
                }
                if (FishFinalSound[i] == arr2[i])
                {
                    Debug.Log($"Match found at index {i}: {FishFinalSound[i]}");

                }
                else
                {
                    allMatch = false;
                    Debug.Log($"No match at index {i}: {FishFinalSound[i]} != {arr2[i]}");
                }

                

                Debug.Log("Array comparison complete.");
                yield return new WaitForSeconds(delayTime);
                // FishSlots[i].GetComponent<FloatingObject>().amplitude = .1f;
                FishSlots[i].GetComponent<FloatingObject>().SetAmplitude(0.1f);
            }
            if (allMatch && AllDrinksCollected())
            {
                LevelClear = true;
                //EmptyFishSlots(FishSlotTone);
                Debug.Log("All elements match! Level clear!");
                LoadNextLevel();
            }
            else
            {
                LevelClear = false;
                Debug.Log("Not all elements match. Level not clear.");
            }
            
        }
    }

    private bool AllDrinksCollected()
    {
        foreach (bool drink in gotDrink)
        {
            if (!drink) return false;
        }
        return true;
    }

    private IEnumerator ChangePitchOverTime(AudioSource audioSource, float startPitch, float targetPitch, float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            audioSource.pitch = Mathf.Lerp(startPitch, targetPitch, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
        audioSource.pitch = targetPitch; // Ensure the final pitch is exactly the target pitch
    }
}
