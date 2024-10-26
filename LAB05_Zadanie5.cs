using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float jumpMultiplier = 3.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                float playerJumpForce = playerRigidbody.mass * Physics.gravity.magnitude;
                Vector3 jumpForce = Vector3.up * playerJumpForce * jumpMultiplier;
                playerRigidbody.AddForce(jumpForce, ForceMode.Impulse);
            }
        }
    }
}
