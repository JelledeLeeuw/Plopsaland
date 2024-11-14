using System.Collections.Generic;
using UnityEngine;

public class PickupsList : MonoBehaviour
{
    public static PickupsList instance;
    public List<GameObject> ActivePickups = new();
    public List<GameObject> CounterTops = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
