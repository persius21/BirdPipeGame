using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.VFX;

public class HideText : MonoBehaviour
{
    
    public Button button1;

    
    public Button button2;

    
    public TextMeshProUGUI Text;

    void Update(){
        button1.onClick.AddListener(setPlayerScoreText);
        button2.onClick.AddListener(setPlayerScoreText);
    }

    void setPlayerScoreText(){
         Text.gameObject.SetActive(true);
    }
}

