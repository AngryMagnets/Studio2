using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private bool isBallLauched = false;
    private Rigidbody ballBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballBody = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall ()
    {
        if (isBallLauched) { return; }
        isBallLauched = true;
        ballBody.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
