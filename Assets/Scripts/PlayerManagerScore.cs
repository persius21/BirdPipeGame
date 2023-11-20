using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerManagerScore : NetworkBehaviour
{
    public Leaderboard leaderboard;
    public GameObject PlayerReference;
    private int score = 0;
    private bool isCoroutineRunning = false;

    private void Update()
    {
        // Check if the coroutine is not running and can be started.
        if (!isCoroutineRunning)
        {
            StartCoroutine(SendScoreUpdates());
        }
    }

    [System.Obsolete]
    private IEnumerator SendScoreUpdates()
    {
        // Set the flag to indicate that the coroutine is running.
        isCoroutineRunning = true;

        // You can access and manage player scores here.
        // For example, you can find all player objects and get their scores.
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            PlayerScore playerScore = player.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                int playerScoreValue = playerScore.GetScore();
                Debug.Log("Player Score: " + playerScoreValue);

                bool isColliding = playerScore.GetisColliding();
                Debug.Log("Is colliding: " + isColliding);

                score = playerScoreValue;

                if (isColliding == true)
                {
                    yield return leaderboard.SubmitScoreRoutine(score);
                    yield return leaderboard.FetchTopHighscoresRoutine();
                }
                else{
                    yield return leaderboard.FetchTopHighscoresRoutine();
                }
            }
        }

        // Wait for a couple of seconds before checking the scores again.
        yield return new WaitForSeconds(2f); // Change 2f to the desired delay in seconds.

        // Set the flag to indicate that the coroutine is no longer running.
        isCoroutineRunning = false;
    }
}
