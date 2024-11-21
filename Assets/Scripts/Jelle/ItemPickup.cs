using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    private float PickUpInputFloat;
    private List<float> PickupDistance = new();
    private int PickupIndex;
    private int Player1Or2;
    private bool CooldownActive;

    [Header("Movement inputs")]
    [SerializeField] private InputAction PickUpInput;

    private void OnEnable()
    {
        PickUpInput.Enable();
    }

    private void OnDisable()
    {
        PickUpInput.Disable();
    }

    private void Start()
    {
        CheckPlayer();
    }

    private void Update()
    {
        SeeIfCooldownActive();
        CheckDistancePickup();
        CheckInput();
        ChooseGrabObject();
        GrabObject();
    }

    private void CheckPlayer()
    {
        if (gameObject.CompareTag("Player1"))
        {
            Player1Or2 = 0;
        }
        else if (gameObject.CompareTag("Player2"))
        {
            Player1Or2 = 1;
        }
        else
        {
            Debug.LogError("Cant check if player is player1 or player2");
        }
    }

    private void SeeIfCooldownActive()
    {
        if(Player1Or2 == 0)
        {
            CooldownActive = CooldownSystem.CooldownSystemScript.CooldownPlayer1;
        }
        else
        {
            CooldownActive = CooldownSystem.CooldownSystemScript.CooldownPlayer2;
        }
    }

    private void CheckDistancePickup()
    {
        if (PickupDistance != null)
        {
            PickupDistance.Clear();
        }

        for (int i = 0; PickupsList.instance.ActivePickups.Count > i; i++)
        {
            PickupDistance.Add(Vector3.Distance(transform.position, PickupsList.instance.ActivePickups[i].transform.position));
        }
    }

    private void CheckInput()
    {
        PickUpInputFloat = PickUpInput.ReadValue<float>();
    }

    private void ChooseGrabObject()
    {
        if(PickUpInputFloat == 1 && CooldownActive == false)
        {
            if (PlayersHolding.PlayerHoldingScript.Player1HoldingObject == false || PlayersHolding.PlayerHoldingScript.Player2HoldingObject == false)
            {
                float ClosestObject = 999;
                for (int i = 0; PickupDistance.Count > i; i++)
                {
                    if (PickupDistance[i] < ClosestObject && PickupDistance[i] < 3)
                    {
                        ClosestObject = PickupDistance[i];
                        PickupIndex = i + 1;
                    }
                }
                if (PickupIndex != 0)
                {
                    PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[Player1Or2] = PickupsList.instance.ActivePickups[PickupIndex - 1];
                }
                PickupIndex = 0;
                StartCooldown();
            }
        }
    }

    private void GrabObject()
    {
        if (PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[Player1Or2] != null)
        {
            PlayersHolding.PlayerHoldingScript.PlayerGameobjectHolding[Player1Or2].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);
            if(Player1Or2 == 0)
            {
                PlayersHolding.PlayerHoldingScript.Player1HoldingObject = true;
            }
            else
            {
                PlayersHolding.PlayerHoldingScript.Player2HoldingObject = true;
            }
        }
    }

    private void StartCooldown()
    {
        if (Player1Or2 == 0)
        {
            CooldownSystem.CooldownSystemScript.CooldownPlayer1 = true;
        }
        else
        {
            CooldownSystem.CooldownSystemScript.CooldownPlayer2 = true;
        }
    }
}
