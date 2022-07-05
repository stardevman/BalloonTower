using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, 0, 1f);
    }
}
