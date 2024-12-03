using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager OrderManagerScript;
    public List<Vector2> TypeOrderAndTimer = new();

    private void Awake()
    {
        if (OrderManagerScript == null)
        {
            OrderManagerScript = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        TypeOrderAndTimer.Clear();
    }
}
