using UnityEngine;
using UnityEngine.InputSystem;

public class TrashCan : MonoBehaviour
{
    private bool CooldownActive1;
    private bool CooldownActive2;
    private bool PutDownTriggerd;
    private Collider CollisionOther;
    private bool isPressed1;
    private bool isPressed2;

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
            isPressed1 = PlaceInputPlayer1.triggered && PlaceInputPlayer1.ReadValue<float>() > 0;
        }
        if (CooldownActive2 == false)
        {
            isPressed2 = PlaceInputPlayer2.triggered && PlaceInputPlayer2.ReadValue<float>() > 0;
        }
    }

    private void PutDownObject()
    {
        if (PutDownTriggerd == true)
        {
            if (CollisionOther.gameObject.CompareTag("Player1") && PlayersHolding.PlayerHoldingScript.Player1HoldingObject == true && isPressed1 && CooldownSystem.CooldownSystemScript.CooldownPlayer1 == false)
            {
                Destroy(PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0]);
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0] = null;
                PlayersHolding.PlayerHoldingScript.Player1HoldingObject = false;
                CooldownSystem.CooldownSystemScript.CooldownPlayer1 = true;
            }
            else if (CollisionOther.gameObject.CompareTag("Player2") && PlayersHolding.PlayerHoldingScript.Player2HoldingObject == true && isPressed2 && CooldownSystem.CooldownSystemScript.CooldownPlayer2 == false)
            {
                Destroy(PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1]);
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1] = null;
                PlayersHolding.PlayerHoldingScript.Player2HoldingObject = false;
                CooldownSystem.CooldownSystemScript.CooldownPlayer2 = true;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            print("yes");
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
    }
}
