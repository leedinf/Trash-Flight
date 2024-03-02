using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
    
    [SerializeField]
    private TextMeshProUGUI text;
    private int coin = 0;

    void Awake(){
        if ( instance == null){
            instance = this;
        }
    }

    public void IncreaseCoin(){
        coin ++;
        text.SetText(coin.ToString());
    }
    
}
