using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    [SerializeField] public AudioClip[] wrongBurps;
    [SerializeField]
    GameObject SFX;
    [SerializeField] Animator NextLevelAnimation;
    [SerializeField] AudioSource nextLevelSound;
    [SerializeField] AudioSource levelClearSound;
    [SerializeField] AudioSource slurpSound;
    [SerializeField] AudioSource serveDrinkSound;
    [SerializeField] AudioSource jukeBox;
    public float delay = 1.0f;

    public bool[] gotDrink;

    public bool LevelClear = false;

    public int[] DrinkValue;

    public int LevelIndex;

    public Mix mix;

    AudioSource burpSound;

    Burp burp;

    private float StartPitch;
    [SerializeField] private float WrongPitch = 1f;

    public ToneIndex toneIndex;
    [SerializeField] private TonePositioning tonePositioning;
    public int correctTone = 0;
    public float targetVolume;
    private bool[] previousMatchState;

    void Start()
    {
        previousMatchState = new bool[FishSlotTone.Length];
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

        ////Debug.Log("Array comparison complete.");
    }

    public IEnumerator AssigneDrink(int Index)
    {
        DrinkValue[Index] = mix.GetDrinkValue();
        mix.ResetDrink();
        gotDrink[Index] = true;
        serveDrinkSound.Play();
        yield return new WaitForSeconds(1);
        slurpSound.Play();
        
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
        for(int i = 0; i < gotDrink.Length; i++)
        {
            gotDrink[i] = false;
        }
        jukeBox.clip = levels[LevelIndex].LevelMusic;
        jukeBox.Play();

        nextLevelSound.Play();
        NextLevelAnimation.StartPlayback();
        tonePositioning.PositionShells(TargetTone);
        tonePositioning.ResetBubbles();
        ////Debug.Log("New Level loaded");
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
                //Debug.LogError("Arrays have different lengths!");
                yield break;
            }
            
            bool allMatch = true;



            for (int i = 0; i < FishSlot.Length; i++)
            {
                toneIndex.moveIndex();
                if (gotDrink[i])
                {
                    switch (FishFinalSound[i])
                    {
                        case 1:
                            if (FishFinalSound[i] == arr2[i])
                            {
                                burpSound.clip = burps[0];
                            }
                            else
                            {
                                burpSound.clip = wrongBurps[0];
                            }
                            break;
                        case 2:
                            if (FishFinalSound[i] == arr2[i])
                            {
                                burpSound.clip = burps[1];
                            }
                            else
                            {
                                burpSound.clip = wrongBurps[1];
                            }
                            break;
                        case 3:
                        if (FishFinalSound[i] == arr2[i])
                        {
                            burpSound.clip = burps[2];
                        }
                        else{
                            burpSound.clip = wrongBurps[2];
                        }
                            break;
                        case 4:
                        if (FishFinalSound[i] == arr2[i])
                        {
                            burpSound.clip = burps[3];
                        }
                        else
                        {
                            burpSound.clip = wrongBurps[3];
                        }
                            break;
                        case 5:
                        if (FishFinalSound[i] == arr2[i])
                        {
                            burpSound.clip = burps[4];
                        }
                        else
                        {
                            burpSound.clip = wrongBurps[4];
                        }
                            break;
                        default:
                            burpSound.clip = burps[0];
                            break;
                    }
                    if (FishFinalSound[i] == arr2[i])
                    {
                        

                        
                        tonePositioning.BubbleColor = Color.green;
                        tonePositioning.PositionBubbles(FishFinalSound[i], i);
                        
                    }
                    else
                    {
                        //burpSound.pitch = WrongPitch;
                        //StartCoroutine(ChangePitchOverTime(burpSound, WrongPitch, StartPitch, delayTime));

                        tonePositioning.BubbleColor = Color.red;
                        tonePositioning.PositionBubbles(FishFinalSound[i], i);
                    }
                    
                    burpSound.Play();

                    FishSlots[i].GetComponent<Burp>().DoBurp();

                }
                if (gotDrink[i])
                {
                    // FishSlots[i].GetComponent<FloatingObject>().amplitude = .5f;
                    FishSlots[i].GetComponent<FloatingObject>().SetAmplitude(0.5f);
                }
                if (FishFinalSound[i] == arr2[i])
                {
                    ////Debug.Log($"Match found at index {i}: {FishFinalSound[i]}");

                }
                else
                {
                    allMatch = false;
                    ////Debug.Log($"No match at index {i}: {FishFinalSound[i]} != {arr2[i]}");
                }

                ////Debug.Log("Array comparison complete.");
                yield return new WaitForSeconds(delayTime);
                // FishSlots[i].GetComponent<FloatingObject>().amplitude = .1f;
                FishSlots[i].GetComponent<FloatingObject>().SetAmplitude(0.1f);

                // bool isMatch = FishSlot[i] == arr2[i];

                // // If the match state has changed (from false to true or vice versa), adjust matchCount
                // if (isMatch != previousMatchState[i])
                // {
                //     if (isMatch)
                //     {
                //         correctTone++; // Increment match count when the match is found
                //     }
                //     else
                //     {
                //         correctTone--; // Decrement match count when the match is lost
                //     }

                //     // Update the previous match state
                //     previousMatchState[i] = isMatch;
                // }
                // targetVolume = (correctTone / (float)FishSlot.Length) * 1.0f;
                // jukeBox.volume =  targetVolume;
            }
            
            if (allMatch && AllDrinksCollected())
            {
                LevelClear = true;
                levelClearSound.Play();
                //EmptyFishSlots(FishSlotTone);
                // //Debug.Log("All elements match! Level clear!");
                LoadNextLevel();
            }
            else
            {
                LevelClear = false;
                ////Debug.Log("Not all elements match. Level not clear.");
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
