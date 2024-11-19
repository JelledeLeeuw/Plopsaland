using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CookingPotQTE : MonoBehaviour
{
    private Slider slider;
    private int sliderSpeed;
    private int sliderPositiveModif;
    private int sliderNegativeModif;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderPositiveModif = 1;
        sliderNegativeModif = 1;
        sliderSpeed = 1;
        slider = GetComponent<Slider>();
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
            sliderSpeed = -1;
        }
        if (slider.value == 0)
        {
            sliderSpeed = 1;
        }
    }

    private void InputCheck()
    {
        if (slider.value >= 0.4 && slider.value <= 0.6f)
        {
            Debug.Log("yes");
        }
        else
        {
            Debug.Log("no");
        }
    }
}
