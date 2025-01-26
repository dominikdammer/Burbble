
using EZCameraShake;
using UnityEngine;
using UnityEngine.VFX;

public class Burp : MonoBehaviour
{
    [SerializeField]
    VisualEffect bubbleEffect;
    [SerializeField]
    GameObject burpPos;
    [SerializeField]
    AudioClip[] burpSounds;
    [SerializeField]
    AudioSource burpy;

    public float magn = 4f, rough = 4f, fadeIn=0.1f, fadeOut = 0.1f;

    private void Start()
    {
        burpy.clip = burpSounds[Random.Range(0, burpSounds.Length)];
        //DoBurp();
    }
    public void DoBurp()
    {
        Instantiate(bubbleEffect,burpPos.transform.position,Quaternion.identity);
        bubbleEffect.Play();
        //CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
        if (burpy != null)

            burpy.Play();
    }

    private void OnDisable()
    {
        burpy.clip = null;
    }
}
