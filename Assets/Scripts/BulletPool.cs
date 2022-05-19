using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bp;

    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        bp = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseBullet(Vector3 pos, float rotZ)
    {
        GameObject temp;

        if (transform.childCount == 0)
        {
            temp = Instantiate(bullet);          
            temp.transform.SetParent(transform);
        }
        else
        {
            temp = transform.GetChild(0).gameObject;
        }

        temp.transform.position = pos;
        temp.transform.localEulerAngles = new Vector3(0, 0, rotZ);
        temp.transform.parent = null;

        temp.SetActive(true);
        temp.GetComponent<Bullet>().MoveBullet();
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.SetParent(transform);
        bullet.transform.position = transform.position;
    }
}
