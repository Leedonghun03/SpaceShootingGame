using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public float rotSpeed = 0;
    public int hp = 0;

    // Start is called before the first frame update
    void Start()
    {
        hp = Random.Range(4, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, rotSpeed * Time.deltaTime);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0) Destroy(gameObject);
    }

}
