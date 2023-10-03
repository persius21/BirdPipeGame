using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class PlayerSpawnRandom : NetworkBehaviour
{
    public override void OnNetworkSpawn(){
        transform.position = new Vector3(Random.Range(-2,0),2,0);

        transform.rotation = Quaternion.Euler(0, 90, 0);

        
    }

}
