using UnityEngine;

public class DeliveringCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Order1")
        {
            OrderManager.Order1OnCounter = true;
            Destroy(other.gameObject);
        }
    }
}
