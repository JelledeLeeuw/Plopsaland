using System;
using UnityEngine;

public class ChangeIngredientState : MonoBehaviour
{
    private MeshFilter meshFilter;
    [SerializeField] private Mesh[] ingredientLook;
    private bool isPrepared;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPrepared = false;
        meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPrepared == false)
            {
                isPrepared = true;
                meshFilter.mesh = ingredientLook[1];
            }
            else if (isPrepared == true)
            {
                isPrepared = false;
                meshFilter.mesh = ingredientLook[0];
            }
        }
    }
}