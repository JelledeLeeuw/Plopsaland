using UnityEngine;

public class CrateItems : MonoBehaviour
{
    [SerializeField] private GameObject ItemInTheCrate;

    private void Start()
    {
        PlaceNewItem();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            PlaceNewItem();
        }
    }

    private void PlaceNewItem()
    {
        Instantiate(ItemInTheCrate, new Vector3(transform.position.x, transform.position.y + 0.3f , transform.position.z), Quaternion.identity); 
    }
}
