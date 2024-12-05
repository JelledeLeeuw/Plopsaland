using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager OrderManagerScript;
    public List<Vector2> TypeOrderAndTimer = new();
    public List<GameObject> TypeOrderGameobject = new();
    public static bool Order1OnCounter;

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
        DeleteCard();
        TypeOrderAndTimer.Clear();
        TypeOrderGameobject.Clear();
    }

    private void DeleteCard()
    {
        int LowestCounterIndex = 0;
        if(Order1OnCounter == true)
        {
            for(int i = 0; i < TypeOrderGameobject.Count; i++) 
            {
                Debug.Log("1");
                if (TypeOrderAndTimer[i].y == 0)
                {
                    if(TypeOrderAndTimer[i].x < TypeOrderAndTimer[LowestCounterIndex].y)
                    {
                        LowestCounterIndex = i;
                    }
                }
            }
            Destroy( TypeOrderGameobject[LowestCounterIndex].gameObject);
            Order1OnCounter = false;
        }
    }
}
