using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;
    // Update is called once per frame

    private float minY = -7f;

    [SerializeField]
    private float hp = 1f;
    public void SetmoveSpeed(float moveSpeed){
        this.moveSpeed = moveSpeed;
    }
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if(transform.position.y < minY){
            Destroy(gameObject);
        }
    }

    //IsTrigger On
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Weapon"){
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;

            if(hp <= 0){
                if(gameObject.tag == "Boss"){
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);
        }
    }
    //IsTrigger Off
    // private void OnCollisionEnter2D(Collision2D other) {
        
    // }
}
