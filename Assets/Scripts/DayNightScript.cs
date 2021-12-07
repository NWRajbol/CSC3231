using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour
{

    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.5f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColour;
    public AnimationCurve sunIntensity;

    public Light light;
    public GameObject clouds;
    public GameObject stars;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColour;
    public AnimationCurve moonIntensity;
    

    [Header("Extra Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectiionsIntensityMultipler;


    public static bool growPlant;

   void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    void Update()
    {
        //increment time

        time += timeRate * Time.deltaTime;

        if (time >= 1.0f)
            time = 0.0f;

        //light rotation
        sun.transform.eulerAngles = (time - 0.25f) * 4.0f * noon;
        moon.transform.eulerAngles = (time - 0.75f) * 4.0f * noon;


        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);
        //change colour 
        sun.color = sunColour.Evaluate(time);
        moon.color = moonColour.Evaluate(time);

        //enable / disable sun

        if (sun.intensity == 0 && sun.gameObject.activeInHierarchy)
        {
            sun.gameObject.SetActive(false);
            light.gameObject.SetActive(false);
            clouds.gameObject.SetActive(false);
            stars.gameObject.SetActive(true);
           
        }
        else if (sun.intensity > 0 && !sun.gameObject.activeInHierarchy)
        {
            sun.gameObject.SetActive(true);
            light.gameObject.SetActive(true);
            clouds.gameObject.SetActive(true);
            stars.gameObject.SetActive(false);

           
        }

        if (moon.intensity == 0 && moon.gameObject.activeInHierarchy)
            moon.gameObject.SetActive(false);
        else if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy)
            moon.gameObject.SetActive(true);


        // lighting and relfections intensity 

        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectiionsIntensityMultipler.Evaluate(time);
    }
}
