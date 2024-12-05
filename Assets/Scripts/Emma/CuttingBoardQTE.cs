using UnityEngine;

public class CuttingBoardQTE : MonoBehaviour
{
    private StationInteraction stationScript;
    private GameObject station;

    //values for calculating points
    private int currentPoints;
    private int targetPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPoints = 0;
        targetPoints = 10;

        station = transform.parent.gameObject;
        stationScript = station.GetComponent<StationInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(stationScript.selectedInput))
        {
            currentPoints++;
            if (currentPoints == targetPoints)
            {
                stationScript.QTEFinished();
            }
        }
    }
}
