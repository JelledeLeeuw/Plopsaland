using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CounterScript : MonoBehaviour
{
    private bool CooldownActive1;
    private bool CooldownActive2;
    private bool PutDownTriggerd;
    private Collider CollisionOther;
    private bool IsPressed1;
    private bool IsPressed2;
    private bool CounterEmpty;

    [Header("PlaceInput inputs")]
    [SerializeField] private InputAction PlaceInputPlayer1;
    [SerializeField] private InputAction PlaceInputPlayer2;

    private void OnEnable()
    {
        PlaceInputPlayer1.Enable();
        PlaceInputPlayer2.Enable();
    }

    private void OnDisable()
    {
        PlaceInputPlayer1.Disable();
        PlaceInputPlayer2.Disable();
    }

    private void Update()
    {
        PutDownObject();
        CheckInput();
    }

    private void CheckInput()
    {
        if (CooldownActive1 == false)
        {
            IsPressed1 = PlaceInputPlayer1.triggered && PlaceInputPlayer1.ReadValue<float>() > 0;
        }
        if (CooldownActive2 == false)
        {
            IsPressed2 = PlaceInputPlayer2.triggered && PlaceInputPlayer2.ReadValue<float>() > 0;
        }
    }

    private void PutDownObject()
    {
        if(PutDownTriggerd == true && CounterEmpty == false)
        {
            if (CollisionOther.gameObject.CompareTag("Player1") && PlayersHolding.PlayerHoldingScript.PlayerHoldingObject[0] == true && IsPressed1 && CooldownSystem.CooldownSystemScript.CooldownPlayer1 == false)
            {
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0] = null;
                PlayersHolding.PlayerHoldingScript.PlayerHoldingObject[0] = false;
                CooldownSystem.CooldownSystemScript.CooldownPlayer1 = true;
                CounterEmpty = true;
            }
            else if (CollisionOther.gameObject.CompareTag("Player2") && PlayersHolding.PlayerHoldingScript.PlayerHoldingObject[1] == true && IsPressed2 && CooldownSystem.CooldownSystemScript.CooldownPlayer2 == false)
            {
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1] = null;
                PlayersHolding.PlayerHoldingScript.PlayerHoldingObject[1] = false;
                CooldownSystem.CooldownSystemScript.CooldownPlayer2 = true;
                CounterEmpty = true;
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            PutDownTriggerd = true;
            CollisionOther = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            PutDownTriggerd = false;
        }

        if (other.gameObject.CompareTag("Pickup"))
        {
            CounterEmpty = false;
            Debug.Log("yahhh");
        }
    }
}
