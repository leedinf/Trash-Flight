using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
    
    [HideInInspector]
    public bool isGameOver = false;
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;
    private int coin = 0;

    void Awake(){
        if ( instance == null){
            instance = this;
        }
    }

    public void IncreaseCoin(){
        coin ++;
        text.SetText(coin.ToString());

        if(coin%5==0){
            Player player = FindObjectOfType<Player>();

            if(player != null){
                player.Upgrade();
            }
        }
    }
    
    public void SetGameOver(){
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();

        isGameOver = true;
        if(spawner != null){
            spawner.StopEnemyRoutine();
        }
        //1초 예약 실행
        Invoke("ShowGameOverPanel",1f);
    }

    void ShowGameOverPanel(){
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("SampleScene");
    }
}
