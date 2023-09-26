using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.VFX;

public class HideText : MonoBehaviour
{
    public TextMeshProUGUI JoinCode;
    public TextMeshProUGUI ScoreText; 
    
    public Button button1;

    
    public Button button2;

    

    void Update(){
        button1.onClick.AddListener(setTextActive);
        button2.onClick.AddListener(setTextActive);
    }

    void setTextActive(){

         ScoreText.gameObject.SetActive(true);
         JoinCode.gameObject.SetActive(true);


         

    }
}

