using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float rotSpeed = 0;
    public float attackRate = 0;
    float time = 0;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, (rotSpeed * Time.deltaTime));

        time += Time.deltaTime;

        if(time > attackRate)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        time = 0;

        GameObject temp = Instantiate(bullet, transform.GetChild(0).position, transform.rotation);
        temp.GetComponent<Bullet>().MoveBullet();
    }
}
