using UnityEngine;
using UnityEngine.InputSystem;

public class StationInteraction : MonoBehaviour
{
    [SerializeField] private GameObject QTEObject;
    private GameObject instantiatedObject;
    private ItemPickup pickupScript;
    private PlayersHolding playersHolding;
    private PlayersMovement playerMovement;
    public KeyCode selectedInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            playersHolding = FindAnyObjectByType<PlayersHolding>();
            pickupScript = other.gameObject.GetComponentInParent<ItemPickup>();
            pickupScript.OnDisable();
            selectedInput = KeyCode.E;
            if (playersHolding.PlayerHoldingObject[0] == true)
            {
                instantiatedObject = Instantiate(QTEObject, transform);
            }
        }
        if (other.CompareTag("Player2"))
        {
            playersHolding = FindAnyObjectByType<PlayersHolding>();
            pickupScript = other.gameObject.GetComponentInParent<ItemPickup>();
            pickupScript.OnDisable();
            selectedInput = KeyCode.Comma;
            if (playersHolding.PlayerHoldingObject[1] == true)
            {
                instantiatedObject = Instantiate(QTEObject, transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            pickupScript.OnEnable();
            if (pickupScript.enabled == false)
            {
                pickupScript.OnEnable();
            }
        }
        if (other.CompareTag("Player2"))
        {
            pickupScript.OnEnable();
            if (pickupScript.enabled == false)
            {
                pickupScript.OnEnable();
            }
        }
    }
    public void QTEFinished()
    {
        Destroy(instantiatedObject);
        Debug.Log(" test successful");
        pickupScript.OnEnable();
    }
}
