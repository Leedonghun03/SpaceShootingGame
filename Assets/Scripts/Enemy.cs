using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 4;
    public int dmg = 2;

    SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Earth"))
        {
            Earth.et.TakeDmg(dmg);
            Destroy(gameObject);
        }
    }

    public void TakeDmg(int dmg)
    {
        hp -= dmg;
        EffectManager.em.SpriteFlash(sr);

        if(hp <=0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        EffectManager.em.EnemyDestroyFX(transform.position);
        Destroy(gameObject);
    }

}
