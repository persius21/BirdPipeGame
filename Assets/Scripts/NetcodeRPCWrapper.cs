using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetcodeRPCWrapper : NetworkBehaviour
{
    public void CallNOOWNERServerRpc(NetworkObject targetObject, string value, Vector3 vector)
    {
        targetObject.GetComponent<NetcodeRPCforVS>().NOOWNERServerRpc(value, vector);
    }
}
