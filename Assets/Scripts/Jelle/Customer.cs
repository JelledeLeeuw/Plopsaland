using System.Collections;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject CustomerSpawnpoint;
    [SerializeField] private GameObject CustomerObject;

    private void Start()
    {
        StartCoroutine(SpawnNewCustomers());
    }

    private IEnumerator SpawnNewCustomers()
    {
        yield return new WaitForSeconds(Random.Range(30,60));
        Instantiate(CustomerObject,CustomerSpawnpoint.transform.position, Quaternion.identity);
        StartCoroutine(SpawnNewCustomers());
    }
}
