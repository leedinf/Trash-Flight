using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

    private float[] arrPosx = { -2f, -1f, 0f, 1f, 2f };
    // Start is called before the first frame update

    [SerializeField]
    private float spawnInterval = 1.5f;
    void Start()
    {
        // foreach (float posX in arrPosx){

        // }
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }
    IEnumerator EnemyRoutine()
    {
        int enemyIndex = 0;
        int spawnCount = 0;
        yield return new WaitForSeconds(3f);
        while (true)
        {
            // int index = UnityEngine.Random.Range(0, enemies.Length);
            // int posIndex = UnityEngine.Random.Range(0, arrPosx.Length);
            foreach(float posX in arrPosx){
                SpawnEnemy(posX, enemyIndex);
            }
            spawnCount++;
            if(spawnCount % 10 == 0){
                enemyIndex++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy(float posX, int index)
    {
        if(index >= enemies.Length){
            index=enemies.Length-1;
        }
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, quaternion.identity);
    }
}
