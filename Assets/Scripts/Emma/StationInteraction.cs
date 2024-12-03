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
    public void QTEFinished()
    {
        Destroy(instantiatedObject);
        Debug.Log(" test successful");
    }
}
