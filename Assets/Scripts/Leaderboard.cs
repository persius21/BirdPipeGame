using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using Newtonsoft.Json;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    int leaderboardID = 17752;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [System.Obsolete]
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.ResetScoreCalls();
        
        LootLockerSDKManager.SubmitScore(playerID,scoreToUpload, leaderboardID,(response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully Uploaded Score");
                done = true;
            }
            else
            {
                Debug.Log("Failed to Upload Score" + response.Error);
                done = true;
            }
        }
        );
        yield return new WaitWhile(()=>done == false);
    }

    [System.Obsolete]
    public IEnumerator FetchTopHighscoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreListMain(leaderboardID, 4, 0,(response)=>
        {
            if(response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember [] members = response.items;
                for (int i=0;i<members.Length;i++)
                {
                    tempPlayerNames += members[i].rank + ".";
                    if (members[i].player.name !="")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score+"\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else 
            {
                Debug.Log("Failed to Show Leaderboard"+response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(()=> done == false);
    }
}
