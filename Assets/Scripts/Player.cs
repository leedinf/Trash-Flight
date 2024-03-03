using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;
    [SerializeField]
    private Transform shootTransform;
    [SerializeField]
    private float shootInterval = 0.05f;
    
    private int weaponIndex = 0;
    private float lastShotTime = 0f;
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // 방향키로 움직이기
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0 , 0);
        // if(Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position -= moveTo;
        // }else if(Input.GetKey(KeyCode.RightArrow)){
        //     transform.position += moveTo;
        // }


        // 마우스 따라 움직이기
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x,-2.3f,2.3f);
        transform.position = new Vector3(toX,transform.position.y,transform.position.z);

        //게임이 끝났는지 확인
        if(GameManager.instance.isGameOver == false) Shoot();
        
    }
    void Shoot(){
        if(Time.time - lastShotTime > shootInterval){
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss"){
            // Debug.Log("Game Over !");
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Coin"){

            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade(){
        weaponIndex +=1;

        if(weaponIndex >= weapons.Length){
            weaponIndex = weapons.Length-1;
        }
    }   
}
