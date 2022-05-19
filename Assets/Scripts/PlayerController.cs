using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController pc;

    public float rotSpeed = 0;

    GameObject ship;

    public GameObject bullet;

    bool isAutoFire = false;
    public float attackRate = 0;
    public float time = 0;


    // Start is called before the first frame update
    void Start()
    {
        pc = this;

        ship = transform.GetChild(0).gameObject;

       // if(bullet == null)
      //  bullet = Resources.Load("/Prefabs/bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gm.isGameStart || GameManager.gm.isDead) return;


        transform.eulerAngles += new Vector3(0, 0, (-rotSpeed * Input.GetAxis("Horizontal")) * Time.deltaTime);
        ship.transform.localEulerAngles = new Vector3(0, 0, Input.GetAxis("Horizontal") * -30);

        time += Time.deltaTime;

        if (!isAutoFire)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (time > attackRate)
                {
                    time = 0;
                    ShootBullet();
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (time > attackRate)
                {
                    time = 0;
                    ShootBullet();
                }
            }
        }


       

    }

    public Transform GetShipTransform()
    {
        return ship.transform;
    }

    void ShootBullet()
    {
        //GameObject temp = Instantiate(bullet, ship.transform.position, Quaternion.identity);
        //temp.transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        //temp.GetComponent<Bullet>().MoveBullet();

        BulletPool.bp.UseBullet(ship.transform.position, transform.localEulerAngles.z);
    }

    public void AutoFire()
    {
        if (isAutoFire) return;

        StartCoroutine(AutoFireTimer());
    }

    IEnumerator AutoFireTimer()
    {
        isAutoFire = true;

        yield return new WaitForSeconds(5);

        isAutoFire = false;
    }

}
