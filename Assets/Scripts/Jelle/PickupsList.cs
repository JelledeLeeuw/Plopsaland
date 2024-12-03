using System.Collections.Generic;
using UnityEngine;

public class PickupsList : MonoBehaviour
{
    public static PickupsList PickupsListScript;
    public List<GameObject> ActivePickups = new();

    private void Awake()
    {
        if (PickupsListScript == null)
        {
            PickupsListScript = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
