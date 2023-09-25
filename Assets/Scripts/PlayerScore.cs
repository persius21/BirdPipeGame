using Unity.Netcode;
using UnityEngine;

public class PlayerScore : NetworkBehaviour
{
    private int score = 0; // Store the player's score.
    private bool isColliding = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointCollider")&& IsOwner)
        {
            // When a player enters a point collider, increase the player's score.
            score++;
            isColliding = true;    
            
        }
        else{
            isColliding = false;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public bool GetisColliding()
    {
        return isColliding;
    }
}
