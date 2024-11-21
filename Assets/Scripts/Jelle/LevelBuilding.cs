using UnityEngine;

public class LevelBuilding : MonoBehaviour
{
    /*
     * 0 Unwalkable
     * 1 Walkable
     * 2 Counter Middle
     * 3 Counter End 1
     * 4 Counter End 2
     * 5 Cauldron
     * 6 Trash can
     * 7 Item Barrel
    */

    private int[,] LevelDesing =
    {
        {5,4,2,2,2,2,2,2,3,5},
        {1,1,1,1,1,1,1,1,1,1},
        {1,1,1,1,1,1,1,1,1,1},
        {4,2,2,3,1,1,4,2,2,3},
        {7,1,1,1,1,1,1,1,1,1},
        {7,1,1,1,1,1,1,1,1,1},
        {7,1,1,4,2,2,3,1,1,1},
        {7,1,1,1,1,1,1,1,1,1},
        {7,1,1,1,1,1,1,1,1,1},
        {4,2,2,2,2,2,2,2,2,3},
    };

    [Header("Kitchen Objects")]
    [SerializeField] private GameObject[] Counters;


    [Header("Kitchen Objects Manager")]
    [SerializeField] private GameObject CounterManager;

    private void Start()
    {
        SpawnKitchen();
    }

    private void SpawnKitchen()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(Counters[LevelDesing[i,j]],new Vector3(j,1,i),Quaternion.identity,CounterManager.transform);
            } 
        }
    }
}
