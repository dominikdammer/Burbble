// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)
 
using UnityEngine;
using System.Collections;
 
// Makes objects float up & down while gently spinning.
public class FloatingObject : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public bool prewarm = false;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    float prewarmModifier;

    private float targetAmplitude;
    private bool isAmplitudeChanging = false;
    public float upwardSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;

        prewarmModifier = Random.Range(0.0f, 0.9f);

        targetAmplitude = amplitude;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        if (prewarm)
        {     
            tempPos.y += Mathf.Sin((Time.fixedTime+ prewarmModifier) * Mathf.PI * frequency) * amplitude ;
        }
        else
        {
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        }

        if (isAmplitudeChanging)
        {
            // Smoothly interpolate the amplitude toward the target
            amplitude = Mathf.MoveTowards(amplitude, targetAmplitude, Time.deltaTime * upwardSpeed);

            // Adjust position upwards proportionally to the change in amplitude
            tempPos.y += upwardSpeed * Time.deltaTime;

            // Stop moving upward once amplitude matches the target
            if (Mathf.Approximately(amplitude, targetAmplitude))
            {
                isAmplitudeChanging = false;
            }
        }
      

        transform.position = tempPos;
    }
    public void SetAmplitude(float newAmplitude)
    {
        targetAmplitude = newAmplitude;
        isAmplitudeChanging = true;
    }
}