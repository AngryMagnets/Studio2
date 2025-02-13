using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform anchor;

    private bool isBallLauched = false;
    private Rigidbody ballBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballBody = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = anchor;
        transform.localPosition = new Vector3(0, -0.5f, 1.2f);
        ballBody.isKinematic = true;
    }

    private void LaunchBall ()
    {
        if (isBallLauched) { return; }
        isBallLauched = true;
        transform.parent = null;
        ballBody.isKinematic = false;
        ballBody.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
