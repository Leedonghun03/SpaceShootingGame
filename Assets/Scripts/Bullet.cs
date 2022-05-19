using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg = 1;

    public float speed = 0;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void MoveBullet()
    {
        rb2d = GetComponent<Rigidbody2D>();

        Vector2 dir = transform.position.normalized * speed;

        rb2d.velocity = dir;

        Invoke("DestroyBullet", 3);
    }

    void DestroyBullet()
    {
        BulletPool.bp.ReturnBullet(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDmg(dmg);
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            collision.GetComponent<ItemComponent>().TakeDamage (dmg);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            collision.GetComponent<EnemyShield>().TakeDamage(dmg);
        }

        CancelInvoke("DestroyBullet");
        EffectManager.em.BulletDestroyFX(transform.position);
        CameraController.cc.Shake(0.1f, 0.1f, 30f);
        DestroyBullet();
    }
}
