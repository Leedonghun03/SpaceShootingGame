using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    SHILED,
    TURRET,
    AUTOBULLET,
    HP
}


public class ItemComponent : MonoBehaviour
{

    public int hp = 6;
    public int time = 5;

    public ItemType iType;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if(hp <= 0)
        {
            GetItem();
            Destroy(gameObject);
        }
    }

    void GetItem()
    {
        if(iType == ItemType.SHILED)
        {
            Earth.et.Shield();
        }
        else if (iType == ItemType.TURRET)
        {
            Earth.et.Turret();
        }
        else if(iType == ItemType.AUTOBULLET)
        {
            PlayerController.pc.AutoFire();
        }
        else
        {
            Earth.et.GetHp();
        }
    }


}
