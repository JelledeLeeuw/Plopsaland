using System.Collections.Generic;
using UnityEngine;

public class PlayersHolding : MonoBehaviour
{
    public static PlayersHolding PlayerHoldingScript;
    public bool[] PlayerHoldingObject;
    public GameObject[] PlayerGameobjectHolding;

    private void Awake()
    {
        if (PlayerHoldingScript == null)
        {
            PlayerHoldingScript = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
