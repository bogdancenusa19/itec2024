using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlickerOnOff : MonoBehaviour
{
    [Header("Objects")]
    public new Light2D light;

    [Header("Attributes")]
    public float minFlickerTime;
    public float maxFlickerTime;

    public float minIntensity;
    public float maxIntensity;

    private float nextFlicker;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= nextFlicker)
        {
            FlickerLight();
            nextFlicker = Time.timeSinceLevelLoad + UnityEngine.Random.Range(minFlickerTime, maxFlickerTime);
        }
    }

    private void FlickerLight()
    {
        if (isOn)
        {
            isOn = false;
            light.intensity = minIntensity;
        }
        else
        {
            isOn = true;
            light.intensity = maxIntensity;
        }
    }
}
