using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemShield;
    public GameObject itemTurret;
    public GameObject itemBullet;
    public GameObject itemHp;

    public float itemSpawnRate = 7;
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

        if(time > itemSpawnRate)
        {
            time = 0;
            SpawnTime();
        }
    }

    void SpawnTime()
    {
        int itemNum = Random.Range(0, 4);
        GameObject item = null;

        if(itemNum == 0)
        {
            item = itemBullet;
        }
        else if (itemNum == 1)
        {
            item = itemTurret;
        }
        else if (itemNum == 2)
        {
            item = itemShield;
        }
        else
        {
            item = itemHp;
        }
        
        float ranDis = Random.Range(2f, 6f);
        int x = 0;
        int y = 0;

        while (true)
        {
            x = Random.Range(-1, 2);
            y = Random.Range(-1, 2);

            if (x != 0 || y != 0) break;
        }

        Vector3 pos = new Vector3(x * ranDis, y * ranDis, 0);

        Instantiate(item, pos, Quaternion.identity);
    }

}
