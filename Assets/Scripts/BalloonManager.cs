using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    [SerializeField] private GameObject balloonPref;
    [SerializeField] private float createSpeed;
    
    [SerializeField] private Rigidbody constPoint;

    [SerializeField] private Color[] balloonColors;

    private void Start()
    {
        InvokeRepeating(nameof(CreateBalloon), 1, createSpeed);
    }

    private void CreateBalloon()
    {
        GameObject balloonIns = Instantiate(balloonPref, constPoint.position + new Vector3(0, 2.0f, 0),
            Quaternion.identity);

        Balloon balloonScript = balloonIns.GetComponent<Balloon>();
        balloonScript.SetBodyColor(balloonColors[Random.Range(0, balloonColors.Length)]);
        balloonScript.SetConnectedBody(constPoint);
    }
}