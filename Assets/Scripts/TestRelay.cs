using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class TestRelay : MonoBehaviour
{
    public TextMeshProUGUI JoinCodeText;
    // Start is called before the first frame update
    public async void Start()
    {
        await UnityServices.InitializeAsync();
        AuthenticationService.Instance.SignedIn += () => {
            Debug.Log("Signed In"+ AuthenticationService.Instance.PlayerId);
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    // Update is called once per frame
     public async void CreateRelay()
    {
        try{
       Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);

       string joincode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

       RelayServerData relayServerData = new RelayServerData(allocation,"dtls");
       NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);

       NetworkManager.Singleton.StartHost();

       JoinCodeText.text = joincode;

    } catch (RelayServiceException e){
        Debug.Log(e);
    }
    }

    public async void JoinRelay(string joincode)
    {
        try{
        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joincode);
        
        RelayServerData relayServerData = new RelayServerData(joinAllocation,"dtls");
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(relayServerData);
        NetworkManager.Singleton.StartClient();

        } catch (RelayServiceException e){
        Debug.Log(e);
    }
        
    }
}
