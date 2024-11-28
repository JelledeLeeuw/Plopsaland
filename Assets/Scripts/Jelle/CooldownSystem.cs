using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownSystem : MonoBehaviour
{
    public static CooldownSystem CooldownSystemScript;
    public bool CooldownPlayer1;
    public bool CooldownPlayer2;

    private bool CoroutineCooldownPlayer1;
    private bool CoroutineCooldownPlayer2;

    private void Awake()
    {
        if (CooldownSystemScript == null)
        {
            CooldownSystemScript = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        StartCooldown();
    }

    private void StartCooldown()
    {
        if (CooldownPlayer1 == true && CoroutineCooldownPlayer1 == false)
        {
            StartCoroutine(CooldownTimer1());
        }

        if (CooldownPlayer2 == true && CoroutineCooldownPlayer2 == false)
        {
            StartCoroutine(CooldownTimer2());
        }
    }

    private IEnumerator CooldownTimer1()
    {
        CoroutineCooldownPlayer1 = true;
        yield return new WaitForSeconds(0.2f);
        CoroutineCooldownPlayer1 = false;
        CooldownPlayer1 = false;
    }

    private IEnumerator CooldownTimer2()
    {
        CoroutineCooldownPlayer2 = true;
        yield return new WaitForSeconds(0.2f);
        CoroutineCooldownPlayer2 = false;
        CooldownPlayer2 = false;
    }
}
