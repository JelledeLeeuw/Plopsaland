using System.Collections;
using TMPro;
using UnityEngine;

public class CustomerTimer : MonoBehaviour
{
    private Vector2 TimerCustomer;
    [SerializeField] private TMP_Text TimeDisplay;
    [SerializeField] private float OrderType;
    [SerializeField] private float Minutes;
    [SerializeField] private float Seconds;

    private void Start()
    {
        StartClock();
    }

    private void Update()
    {
        UpdateClock();
        OnTimerEnd();
    }

    private void LateUpdate()
    {
        UpdateOrderList();
    }

    private void StartClock()
    {
        TimerCustomer = new Vector2(Minutes, Seconds);
        StartCoroutine(TimeUpdate());
    }

    private void UpdateClock()
    {
        if (TimerCustomer[1] > 9)
        {
            TimeDisplay.text = TimerCustomer[0].ToString() + ":" + TimerCustomer[1].ToString();
        }
        else
        {
            TimeDisplay.text = TimerCustomer[0].ToString() + ":" + "0" + TimerCustomer[1].ToString();
        }
    }

    private void UpdateOrderList()
    { 
        OrderManager.OrderManagerScript.TypeOrderAndTimer.Add(new Vector2((TimerCustomer[0] * 60) + TimerCustomer[1], OrderType));
    }

    private void OnTimerEnd()
    {
        if(TimerCustomer == Vector2.zero)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator TimeUpdate()
    {
        yield return new WaitForSeconds(1);
        TimerCustomer[1] -= 1;
        if (TimerCustomer[1] == -1)
        {
            TimerCustomer[1] = 59;
            TimerCustomer[0] -= 1;
        }
        StartCoroutine(TimeUpdate());
    }
}
