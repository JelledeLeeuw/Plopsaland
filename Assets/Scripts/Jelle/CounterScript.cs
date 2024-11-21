using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CounterScript : MonoBehaviour
{
    private Vector2 PlaceInputsVector2;
    private bool CooldownActive1;
    private bool CooldownActive2;

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
         CheckInput();
    }

    private void CheckIfCooldown()
    {
            if (PlaceInputsVector2[0] == 1)
            {
                StartCoroutine(CooldownTimer1());
            }
        
            if(PlaceInputsVector2[1] == 1)
            {
                StartCoroutine(CooldownTimer2());
            }
    }

    private void CheckInput()
    {
        if (CooldownActive1 == false)
        {
            PlaceInputsVector2[0] = PlaceInputPlayer1.ReadValue<float>();
        }
        if (CooldownActive2 == false)
        {
            PlaceInputsVector2[1] = PlaceInputPlayer2.ReadValue<float>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") && PlayersHolding.PlayerHoldingScript.Player1HoldingObject == true && PlaceInputsVector2[0] == 1)
        {
            PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
            PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[0] = null;
            PlayersHolding.PlayerHoldingScript.Player1HoldingObject = false;
        }
        else if (other.gameObject.CompareTag("Player2") && PlayersHolding.PlayerHoldingScript.Player2HoldingObject == true && PlaceInputsVector2[1] == 1)
        {
            PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z);
            PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[1] = null;
            PlayersHolding.PlayerHoldingScript.Player2HoldingObject = false;
        }
        //CheckIfCooldown();
    }

    private IEnumerator CooldownTimer1()
    {
        PlaceInputsVector2[0] = 0;
        CooldownActive1 = true;
        yield return new WaitForSeconds(1);
        CooldownActive1 = false;
    }

    private IEnumerator CooldownTimer2()
    {
        PlaceInputsVector2[1] = 0;
        CooldownActive2 = true;
        yield return new WaitForSeconds(1);
        CooldownActive2 = false;
    }
}
