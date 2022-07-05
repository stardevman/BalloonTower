using UnityEngine;

public class StringRenderer : MonoBehaviour
{
    [SerializeField] private Transform stringEndpoint;
    
    private LineRenderer _lineRenderer;
    private Transform _connectedObj; 

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, stringEndpoint.position);
        _lineRenderer.SetPosition(1, _connectedObj.position);
    }

    public void SetConnectedObj(Transform obj)
    {
        _connectedObj = obj;
    }
}
