using System.Collections;
using System.Collections.Generic;
using LootLocker.Requests;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerName : NetworkBehaviour
{
    public TMP_InputField PlayerNameInput;
    public Button HostBTN;
    public Button ClientBTN;
    public Leaderboard leaderboard;

    void Start(){
        HostBTN.onClick.AddListener(OnHostBtnClick);
        ClientBTN.onClick.AddListener(OnClientBtnClick);
    }

    void OnHostBtnClick()
    {
        StartCoroutine(ChangePlayerNameRoutine());
        StartCoroutine(leaderboard.SubmitScoreRoutine(0));
        StartCoroutine(leaderboard.FetchTopHighscoresRoutine());
        
        NetworkManager.StartHost();
        
        HostBTN.transform.parent.gameObject.SetActive(false); // Hide the parent GameObject
    }
    void OnClientBtnClick()
    {
        StartCoroutine(ChangePlayerNameRoutine());
        StartCoroutine(leaderboard.SubmitScoreRoutine(0));
        StartCoroutine(leaderboard.FetchTopHighscoresRoutine());
        
        NetworkManager.StartClient();
        ClientBTN.onClick.AddListener(OnClientBtnClick); // Hide the parent GameObject
    }

    
 IEnumerator ChangePlayerNameRoutine(){
        bool done = false;
        string PlayerName = PlayerNameInput.text;

        LootLockerSDKManager.SetPlayerName(PlayerName,(response)=>
        {
            if(response.success){
                Debug.Log("Player was named "+PlayerName);
                
                done = true;
                }
            else {
                Debug.Log("Could not Change name");
                }
                });     
        yield return new WaitWhile(()=>done == false);
        
        
    }
   


}
