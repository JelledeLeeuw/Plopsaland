using System.Collections.Generic;
using UnityEngine;

public class PlayersHolding : MonoBehaviour
{
    public static PlayersHolding PlayerHoldingScript;
    public bool Player1HoldingObject;
    public bool Player2HoldingObject;
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
