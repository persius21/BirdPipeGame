using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToMainMenu : NetworkBehaviour
{
    public Button mainExitBTN;
    void Start()
    {
        mainExitBTN.onClick.AddListener(ExittoMain);   
    }

    // Update is called once per frame
    void ExittoMain()
    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     NetworkManager.Shutdown();   
    }
}


