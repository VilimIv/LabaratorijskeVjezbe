using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (IsOwner)
        {
            // Capture player input
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Send input to the server
            SubmitMoveServerRpc(movement);
        }
    }

    [ServerRpc]
    void SubmitMoveServerRpc(Vector3 movement)
    {
        // Apply movement on the server
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        // Update the position on all clients
        UpdatePositionClientRpc(rb.position);
    }

    [ClientRpc]
    void UpdatePositionClientRpc(Vector3 newPosition)
    {
        if (!IsOwner)
        {
            // Update position on non-owning clients
            rb.position = newPosition;
        }
    }
}
