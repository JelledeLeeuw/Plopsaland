using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    private bool HoldingObject;
    private float PickUpInputFloat;
    private List<float> PickupDistance = new();
    private List<float> CounterDistance = new();
    private int PickupIndex;
    private GameObject ItemHolding;

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

    private void Update()
    {
        CheckDistancePickup();
        CheckInput();
        ChooseGrabObject();
        GrabObject();
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
        if(PickUpInputFloat == 1 && HoldingObject == false)
        {
            float ClosestObject = 999;
            for (int i = 0; PickupDistance.Count > i; i++)
            {
                if(PickupDistance[i] < ClosestObject && PickupDistance[i] < 3)
                {
                    ClosestObject = PickupDistance[i];
                    PickupIndex = i + 1;
                }
            }
            if (PickupIndex != 0)
            {
                ItemHolding = PickupsList.instance.ActivePickups[PickupIndex - 1];
            }
            PickupIndex = 0;
        }
    }

    private void GrabObject()
    {
        if(ItemHolding != null)
        {
            ItemHolding.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);
            HoldingObject = true;
        }
    }

    private void ChooseCounter()
    {
        if (PickUpInputFloat == 1 && HoldingObject == true)
        {
            float ClosestObject = 999;
            for (int i = 0; CounterDistance.Count > i; i++)
            {
                if (CounterDistance[i] < ClosestObject && PickupDistance[i] < 3)
                {
                    ClosestObject = PickupDistance[i];
                    PickupIndex = i + 1;
                }
            }
            if (PickupIndex != 0)
            {
                ItemHolding = PickupsList.instance.ActivePickups[PickupIndex - 1];
            }
            PickupIndex = 0;
        }
    }
}
