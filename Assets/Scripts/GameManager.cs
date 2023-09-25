using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using Unity.Netcode;
using Unity.Networking;
using Unity.Networking.Transport;

public class GameManager : NetworkBehaviour
{
    private List<PlayerCollision> players = new List<PlayerCollision>();
    private bool isCoroutineRunning = false;
    private bool allPlayersDead = false; // Track if all players are dead

    // Start is called before the first frame update
    private void Start()
    {
        // Start the coroutine to periodically check player states
        StartCoroutine(CheckPlayerStates());
    }

    private IEnumerator CheckPlayerStates()
    {
        // Wait for a moment before starting the loop (adjust the delay as needed)
        yield return new WaitForSeconds(1f);

        // Continuously check player states
        while (true)
        {
            // Find all player objects in the scene and add them to the list
            GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
            players.Clear(); // Clear the list and re-populate it
            foreach (GameObject playerObject in playerObjects)
            {
                PlayerCollision playerCollision = playerObject.GetComponent<PlayerCollision>();
                if (playerCollision != null)
                {
                    players.Add(playerCollision);
                }
            }

            // Check if there are any players in the scene
            bool anyPlayersInScene = players.Count > 0;

            // Check if all players are dead
            allPlayersDead = true; // Assume all players are dead
            foreach (PlayerCollision player in players)
            {
                if (player.IsAlive())
                {
                    allPlayersDead = false; // If any player is alive, set to false
                    break;
                }
            }

            // If all players are dead and there are players in the scene, reset the scene
            if (allPlayersDead && anyPlayersInScene)
            {
                RpcResetSceneClientRpc();
            }

            // Wait for a moment before checking again (adjust the delay as needed)
            yield return new WaitForSeconds(5f); // Change 2f to the desired delay in seconds
        }
    }

    private void ResetScene()
    {
        // Reload the current scene
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
       
    }
     [ClientRpc]
    public void RpcResetSceneClientRpc()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         NetworkManager.Shutdown();
    }
    
    
    
}
