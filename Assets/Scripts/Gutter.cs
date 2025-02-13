using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody ballBody = other.GetComponent<Rigidbody>();
        float velocityMagnitude = ballBody.linearVelocity.magnitude;
        ballBody.linearVelocity = Vector3.zero;
        ballBody.angularVelocity = Vector3.zero;

        ballBody.AddForce(transform.up *  velocityMagnitude, ForceMode.VelocityChange);
    }
}
