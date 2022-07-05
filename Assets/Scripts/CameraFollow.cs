using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothness;

    private Vector3 _refV3;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + _offset, ref _refV3, smoothness);
    }
}