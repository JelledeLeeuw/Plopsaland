using UnityEngine;

public class PickupsAddToList : MonoBehaviour
{
    private void Start()
    {
        PickupsList.instance.ActivePickups.Add(gameObject);
    }

    private void OnDestroy()
    {
        PickupsList.instance.ActivePickups.Remove(gameObject);
    }
}
