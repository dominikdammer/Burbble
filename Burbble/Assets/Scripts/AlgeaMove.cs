using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgeaMove : MonoBehaviour
{

    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        lr.endWidth += Mathf.Lerp(1f, 0.8f, 3f);


    }
}
