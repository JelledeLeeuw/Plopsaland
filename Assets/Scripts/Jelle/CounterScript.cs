using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CounterScript : MonoBehaviour
{
    private Vector2 PlaceInputsVector2;
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

    private void FixedUpdate()
    {
         
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
            isPressed2 = PlaceInputPlayer1.triggered && PlaceInputPlayer1.ReadValue<float>() > 0;
        }
    }

    private void PutDownObject()
    {
        if(PutDownTriggerd == true)
        {
            if (CollisionOther.gameObject.CompareTag("Player1") && PlayersHolding.PlayerHoldingScript.Player1HoldingObject == true && isPressed1 && CooldownSystem.CooldownSystemScript.CooldownPlayer1 == false)
            {
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0] = null;
                PlayersHolding.PlayerHoldingScript.Player1HoldingObject = false;
                CooldownSystem.CooldownSystemScript.CooldownPlayer1 = true;
                PutDownTriggerd = false;
            }
            else if (CollisionOther.gameObject.CompareTag("Player2") && PlayersHolding.PlayerHoldingScript.Player2HoldingObject == true && isPressed2 && CooldownSystem.CooldownSystemScript.CooldownPlayer2 == false)
            {
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
                PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1] = null;
                PlayersHolding.PlayerHoldingScript.Player2HoldingObject = false;
                CooldownSystem.CooldownSystemScript.CooldownPlayer2 = true;
                PutDownTriggerd = false;
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player1"))
        {
            print("yes");
            PutDownTriggerd = true;
            CollisionOther = other;
        }
    }
}
