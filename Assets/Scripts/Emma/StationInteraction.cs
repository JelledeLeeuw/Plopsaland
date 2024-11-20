using UnityEngine;

public class StationInteraction : MonoBehaviour
{
    [SerializeField] private GameObject QTEObject;
    private GameObject instantiatedObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instantiatedObject = Instantiate(QTEObject, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QTEFinished()
    {
        Destroy(instantiatedObject);
        Debug.Log(" test successful");
    }
}
