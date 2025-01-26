using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonePositioning : MonoBehaviour
{
    [SerializeField] GameObject[] Shells;
    [SerializeField] GameObject[] Bubbles;
    [SerializeField] Transform[] ToneTransform;
    public Color BubbleColor = Color.white;

    public void PositionShells(int[] FishSlotTone)
    {
        for (int x = 0; x < FishSlotTone.Length; x++)
        {
            for (int i = 0; i < ToneTransform.Length; i++)
            {
                if (i == FishSlotTone[x] + 5 * x)
                {
                    //Shells[i].transform.position = ToneTransform[i].position;
                    //Debug.Log("TonePosition" + i);
                    Shells[x].transform.SetParent(ToneTransform[i]);
                    Shells[x].transform.position = ToneTransform[i].position;

                    //Shells[x].gameObject.SetActive(true);

                }
            }
        }
        
    }

    public void PositionBubbles(int FishFinalSound, int x)
    {
            for (int i = 0; i < ToneTransform.Length; i++)
            {
                if (i == FishFinalSound + 5 * x)
                {
                    //Shells[i].transform.position = ToneTransform[i].position;
                    Debug.Log("TonePosition" + i);
                    Bubbles[x].transform.SetParent(ToneTransform[i]);
                    Bubbles[x].transform.position = ToneTransform[i].position;

                    if(!Bubbles[x].gameObject.activeSelf)
                    {
                        Bubbles[x].gameObject.SetActive(true);
                    }
                    Bubbles[x].GetComponent<SpriteRenderer>().color = BubbleColor;

                    //Shells[x].gameObject.SetActive(true);

                }
            }
    }
    public void ResetBubbles()
    {
        for (int i = 0; i < Bubbles.Length; i++)
        {
            if(Bubbles[i].gameObject.activeSelf)
            {
                Bubbles[i].gameObject.SetActive(false);
            }
        }
        
    }
}
