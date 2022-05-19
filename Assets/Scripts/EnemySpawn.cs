using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Rect spawnBoundery;

    public float spawnRate = 2;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gm.isGameStart || GameManager.gm.isDead) return;


        time += Time.deltaTime;

        if(time > spawnRate)
        {
            time = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float spawnPos = Random.Range(0, 4);
        Vector3 pos = Vector3.zero;
        
        if(spawnPos == 0)
        {
            pos = new Vector3(spawnBoundery.xMin, Random.Range(spawnBoundery.yMin, spawnBoundery.yMax), 0);
        }
        else if(spawnPos == 1)
        {
            pos = new Vector3(spawnBoundery.xMax, Random.Range(spawnBoundery.yMin, spawnBoundery.yMax), 0);
        }
        else if (spawnPos == 2)
        {
            pos = new Vector3(Random.Range(spawnBoundery.xMin, spawnBoundery.xMax), spawnBoundery.yMax, 0);
        }
        else
        {
            pos = new Vector3(Random.Range(spawnBoundery.xMin, spawnBoundery.xMax), spawnBoundery.yMin, 0);
        }
        
        GameObject temp = Instantiate(enemy, pos, Quaternion.identity);

    }

}
