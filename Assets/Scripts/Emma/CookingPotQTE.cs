using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CookingPotQTE : MonoBehaviour
{
    private StationInteraction stationScript;
    private GameObject station;
    private Slider slider;

    //values for moving the slider
    private int sliderSpeed;
    private int sliderPositiveModif;
    private int sliderNegativeModif;

    //values for calculating points
    private int currentPoints;
    private int targetPoints;
    private int pointUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        station = transform.parent.gameObject;
        stationScript = station.GetComponent<StationInteraction>();
        currentPoints = 0;
        targetPoints = 3;
        pointUp = 1;
        sliderPositiveModif = 1;
        sliderNegativeModif = -1;
        sliderSpeed = 1;
        slider = GetComponentInChildren<Slider>();
        Debug.Log(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InputCheck();
        }
        slider.value = slider.value + (sliderSpeed * Time.deltaTime);

        if (slider.value == 1)
        {
            sliderSpeed = sliderNegativeModif;
        }
        if (slider.value == 0)
        {
            sliderSpeed = sliderPositiveModif;
        }
    }

    private void InputCheck()
    {
        if (slider.value >= 0.4 && slider.value <= 0.6f)
        {
            currentPoints = currentPoints + pointUp;
            if (currentPoints == targetPoints)
            {
                //finishes the QTE via the StationInteraction script
                stationScript.QTEFinished();
            }
        }
    }
}
