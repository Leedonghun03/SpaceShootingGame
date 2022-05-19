using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss1 : Enemy
{
    public GameObject child;

    public override void Die()
    {
        CreateChild();
        base.Die();
    }

    void CreateChild()
    {
        Instantiate(child, transform.position + (transform.right * 0.5f), Quaternion.identity);
        Instantiate(child, transform.position + (transform.right * -0.5f), Quaternion.identity);
        Instantiate(child, transform.position + (transform.up * 0.5f), Quaternion.identity);
    }

}
