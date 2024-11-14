using UnityEngine;

public class CounterToAddToList : MonoBehaviour
{
    private void Start()
    {
        PickupsList.instance.CounterTops.Add(gameObject);
    }
}
