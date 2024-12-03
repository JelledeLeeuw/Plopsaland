using UnityEngine;

public class PickupsAddToList : MonoBehaviour
{
    private void Start()
    {
        PickupsList.PickupsListScript.ActivePickups.Add(gameObject);
    }

    private void OnDestroy()
    {
        PickupsList.PickupsListScript.ActivePickups.Remove(gameObject);
    }
}
