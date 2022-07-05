using System.Collections;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float inflateSpeed;
    [SerializeField] private float gravityValue;

    [SerializeField] private MeshRenderer meshRenderer;

    private Rigidbody _rb;
    private CapsuleCollider _capsuleCollider;
    private StringRenderer _stringRenderer;
    private ConfigurableJoint _configurableJoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _stringRenderer = GetComponent<StringRenderer>();
        _configurableJoint = GetComponent<ConfigurableJoint>();
        _capsuleCollider = GetComponentInChildren<CapsuleCollider>();
    }

    private void OnEnable()
    {
        StartCoroutine(EnableCapsuleCollider());
        StartCoroutine(Inflate());
    }

    private void FixedUpdate()
    {
        //For inverse gravity
        _rb.velocity = new Vector3(0, gravityValue, 0);
    }

    private IEnumerator EnableCapsuleCollider()
    {
        float randomTime = Random.Range(0.25f, 1f);
        yield return new WaitForSeconds(randomTime);
        
        _capsuleCollider.enabled = true;
    }

    private IEnumerator Inflate()
    {
        //Reset scale
        transform.localScale = new Vector3(0, 0, 0);

        while (transform.localScale.y < 1.0f)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * (inflateSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void SetBodyColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    public void SetConnectedBody(Rigidbody body)
    {
        _configurableJoint.connectedBody = body;
        _stringRenderer.SetConnectedObj(body.transform);
    }
}