using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController cc;
    Camera cam;

    public float speed = 0;
    bool isShake = false;

    float time = 0;
    public bool isCamMove = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = this;
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isCamMove)
            ChangeSize();
    }

    private void LateUpdate()
    {
        if (!GameManager.gm.isGameStart) return;

        transform.position = Vector3.Lerp(transform.position, PlayerController.pc.GetShipTransform().position, speed * Time.deltaTime);
    }

    public void Shake(float _dur, float offset, float intensity)
    {
        if (isShake)
        {
            StopCoroutine("ShakeCam");
        }
        StartCoroutine(ShakeCam(_dur, offset, intensity));
    }

    IEnumerator ShakeCam(float _dur, float offset, float intensity)
    {
        float time = _dur;
        Vector3 curPos = cam.transform.localPosition;
        Vector3 targetPos = Vector3.zero;
        isShake = true;

        while(time > 0)
        {
            if(targetPos == Vector3.zero)
            {
                targetPos = curPos + (Random.insideUnitSphere * offset);
            }

            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, targetPos, intensity * Time.deltaTime);

            if(Vector3.Distance(cam.transform.localPosition, targetPos) < 0.02f)
            {
                targetPos = Vector3.zero;
            }

            time -= Time.deltaTime;
            yield return null;
        }

        cam.transform.localPosition = curPos;
        isShake = false;

        

    }

    void ChangeSize()
    {
        time += Time.deltaTime;

        float currentSize = cam.orthographicSize;

        cam.orthographicSize = Mathf.Lerp(currentSize, 4, time * 0.1f);

        if(time >= 1)
        {
            isCamMove = false;
            GameManager.gm.GameStart();
        }
    }
}
