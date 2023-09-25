using Unity.Netcode;
using UnityEngine;

public class PlayerScore : NetworkBehaviour
{
    private int score = 0; // Store the player's score.
    private bool isColliding = false;
    private bool isAlive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointCollider")&& IsOwner)
        {
            if(isAlive==true){
            // When a player enters a point collider, increase the player's score.
            score++;
            isColliding = true;
            }    
            
        }
        else{
            isColliding = false;
        }
    }

 private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            // When a player collides with a pipe, change the isAlive boolean to false.
            isAlive = false;
            
            // You can add any additional logic here, such as playing a death animation or sound.
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
