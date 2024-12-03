using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public static Vector2 Timer;
    [SerializeField] private TMP_Text TimeDisplay;
    [SerializeField] private float Minutes;
    [SerializeField] private float Seconds;

    private void Start()
    {
        StartClock();
    }

    private void Update()
    {
        UpdateClock();
    }

    private void StartClock()
    {
        Timer = new Vector2(Minutes, Seconds);
        StartCoroutine(TimeUpdate());
    }

    private void UpdateClock()
    {
        if(Timer[1] > 9)
        {
            TimeDisplay.text = Timer[0].ToString() + ":" + Timer[1].ToString();
        }
        else
        {
            TimeDisplay.text = Timer[0].ToString() + ":" + "0" + Timer[1].ToString();
        }
    }

    private IEnumerator TimeUpdate()
    {
        yield return new WaitForSeconds(1);
        Timer[1] -= 1;
        if (Timer[1] == -1)
        {
            Timer[1] = 59;
            Timer[0] -= 1;
        }
        StartCoroutine(TimeUpdate());
    }
}
