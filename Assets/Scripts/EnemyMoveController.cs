using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    public float speed = 0;

  

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gm.isGameStart || GameManager.gm.isDead) return;

        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
        SetAngle();
    }

    void SetAngle()
    {
        Vector3 dir = transform.position - Vector3.zero;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg+90;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

}
