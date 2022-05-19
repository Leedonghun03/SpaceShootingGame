using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool isGameStart = false;
    public bool isDead = false;

    public float playTime = 0;
    public float bestTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;

        if (PlayerPrefs.HasKey("BestTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestTime");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CameraController.cc.isCamMove = true;
            }
        }
        else
        {
            playTime += Time.deltaTime;
        }
    }

    public void GameStart()
    {
        isGameStart = true;
        UIManager.um.StartUIOff();
    }

    public void GameOver()
    {
        isDead = true;
        UIManager.um.GameOverUI();
    }

    public void SetBestTime()
    {
        PlayerPrefs.SetFloat("BestTime", playTime);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
