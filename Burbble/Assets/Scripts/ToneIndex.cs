using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToneIndex : MonoBehaviour
{
    [SerializeField] public GameObject TactLine;
    public int indexPosition = 4;
    [SerializeField] public GameObject[] Slots;
    public void moveIndex()
    {
        if(indexPosition <= 5)
        {
            TactLine.transform.position = Slots[indexPosition].transform.position;
            indexPosition++;
        }
        else
        {
            indexPosition = 0;
            TactLine.transform.position = Slots[indexPosition].transform.position;
            indexPosition++;
        }
    }
}
