using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;
using System;

public class NetcodeRPCforVS : NetworkBehaviour
{

    [ServerRpc]
    public void VSServerRpc(string value){
        CustomEvent.Trigger(gameObject, value);

    }

     [ServerRpc]
    public void VSServerRpc(string value, int num){
        CustomEvent.Trigger(gameObject, value, num);

    }

     [ServerRpc]
    public void VSServerRpc(string value, Vector3 vector){
        CustomEvent.Trigger(gameObject, value, vector);

    }

     [ServerRpc]
    public void VSServerRpc(string value, float num){
        CustomEvent.Trigger(gameObject, value, num);

    }

    [ServerRpc(RequireOwnership = false)]
    public void NOOWNERServerRpc(string value, Vector3 vector){
        CustomEvent.Trigger(gameObject, value, vector);
    }

    
    [ClientRpc]
    public void VSClientRPC(string value){
         CustomEvent.Trigger(gameObject, value);
    }

    [ClientRpc]
    public void VSClientRPC(string value, int num){
         CustomEvent.Trigger(gameObject, value, num);
    }

    [ClientRpc]
    public void VSClientRPC(string value, Vector3 vector){
         CustomEvent.Trigger(gameObject, value, vector);
    }

    [ClientRpc]
    public void VSClientRPC(string value, float num){
         CustomEvent.Trigger(gameObject, value, num);
    }

}
