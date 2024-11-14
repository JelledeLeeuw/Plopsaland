using UnityEngine;

public class PickupsAddToList : MonoBehaviour
{
    private void Start()
    {
        PickupsList.instance.ActivePickups.Add(gameObject);
    }
}
