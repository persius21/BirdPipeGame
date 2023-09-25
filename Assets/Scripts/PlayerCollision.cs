using Unity.Netcode;
using UnityEngine;

public class PlayerCollision : NetworkBehaviour
{
    private bool isAlive = true;

    // This method is called when a collision occurs with another GameObject's collider.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            // When a player collides with a pipe, change the isAlive boolean to false.
            isAlive = false;
            
            // You can add any additional logic here, such as playing a death animation or sound.
        }
    }

    // This method allows other scripts to query the player's current state.
    public bool IsAlive()
    {
        return isAlive;
    }
}
