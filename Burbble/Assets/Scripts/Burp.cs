using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class Burp : MonoBehaviour
{
    [SerializeField]
    VisualEffect bubbleEffect;
    [SerializeField]
    GameObject burpPos;
    [SerializeField]
    AudioSource burpSound;

    public float magn = 4, rough = 4, fadeIn, fadeOut;

    private void Start()
    {
        DoBurp();
    }
    public void DoBurp()
    {
        Instantiate(bubbleEffect,burpPos.transform.position,Quaternion.identity);
        bubbleEffect.Play();
        CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
        if(burpSound != null) 
        burpSound.Play();

    }
}
