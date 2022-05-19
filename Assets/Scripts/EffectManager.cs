using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager em;
    public GameObject bulletFX;
    public GameObject enemyFX;
    public GameObject earthFX;

    // Start is called before the first frame update
    void Start()
    {
        em = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BulletDestroyFX(Vector3 pos)
    {
        CreatFx(pos, bulletFX);
    }

    public void EnemyDestroyFX(Vector3 pos)
    {
        CreatFx(pos, enemyFX);
    }

    public void EarthDestroyFX(Vector3 pos)
    {
        CreatFx(pos, earthFX);
    }

    void CreatFx(Vector3 pos, GameObject fx)
    {
        GameObject temp = Instantiate(fx, pos, Quaternion.identity);
        Destroy(temp, 1);
    }

    public void SpriteFlash(SpriteRenderer sr)
    {
        StartCoroutine(SpriteFlashCor(sr));
    }

    IEnumerator SpriteFlashCor(SpriteRenderer sr)
    {
        if (sr.color != Color.red)
        {
            Color cor = sr.color;
            sr.color = Color.red;

            yield return new WaitForSeconds(0.05f);

            if (sr != null)
            sr.color = cor;
        }
    }

}
