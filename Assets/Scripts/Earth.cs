using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public static Earth et;

    public int maxHp = 50;
    public int hp = 0;

    SpriteRenderer sr;

    public GameObject shield;
    public GameObject turret;
    bool isShield = false;
    bool isTurret = false;

    // Start is called before the first frame update
    void Start()
    {
        et = this;
        hp = maxHp;

        UIManager.um.SetMaxHpUI(hp);
        UIManager.um.SetHpUI(hp);

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDmg(int dmg)
    {
        if (!isShield)
        {
            hp -= dmg;
            EffectManager.em.SpriteFlash(sr);
            UIManager.um.SetHpUI(hp);
        }

        CameraController.cc.Shake(0.3f, 0.3f, 50);

        if (hp <= 0)
        {
            GameManager.gm.GameOver();
            EffectManager.em.EarthDestroyFX(transform.position);
            Destroy(gameObject);
        }
    }

    public void Turret()
    {
        if (isTurret) return;

        StartCoroutine(TurretTimer());
    }

    IEnumerator TurretTimer()
    {
        isTurret = true;
        turret.SetActive(true);

        yield return new WaitForSeconds(5);

        isTurret = false;
        turret.SetActive(false);
    }

    public void Shield()
    {
        if (isShield) return;

        StartCoroutine(ShieldTimer());
    }

    IEnumerator ShieldTimer()
    {
        isShield = true;
        shield.SetActive(true);

        yield return new WaitForSeconds(5);

        isShield = false;
        shield.SetActive(false);
    }

    public void GetHp()
    {
        hp += 10;

        if(hp > maxHp)
        {
            hp = maxHp;
        }
        UIManager.um.SetHpUI(hp);
    }

}
