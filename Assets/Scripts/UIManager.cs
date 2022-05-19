using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager um;

    public GameObject hpUI;
    public GameObject timeUI;
    public GameObject startUI;
    public GameObject overUI;

    // Start is called before the first frame update

    private void Awake()
    {
        um = this;
    }
    
    void Start()
    {
        //timeUI = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        SetTimer();
    }

    public void SetHpUI(int _hp)
    {
        hpUI.GetComponent<Slider>().value = _hp;
    }

    public void SetMaxHpUI(int _hp)
    {
        hpUI.GetComponent<Slider>().maxValue = _hp;
    }

    void SetTimer()
    {
        if (timeUI.activeInHierarchy)
        {
            timeUI.GetComponent<Text>().text = "Time Record\n<size=55>" + GetTimeString(GameManager.gm.playTime) + "</size>";
        }
    }

    string GetTimeString(float time)
    {
        string mins = Mathf.FloorToInt(time / 60).ToString();

        if (int.Parse(mins) < 10)
            mins = "0" + mins;

        string sec = ((int)time % 60).ToString();

        if (int.Parse(sec) < 10)
            sec = "0" + sec;

        return mins + ":" + sec;
    }

    public void StartUIOff()
    {
        startUI.SetActive(false);

        hpUI.SetActive(true);
        timeUI.SetActive(true);
    }

    public void GameOverUI()
    {
        hpUI.SetActive(false);
        timeUI.SetActive(false);

        overUI.SetActive(true);
        overUI.transform.GetChild(1).GetComponent<Text>().text = "Your Play Time \n<size=55>" + GetTimeString(GameManager.gm.playTime) + "</size>";
        if (GameManager.gm.bestTime == 0 || GameManager.gm.playTime > GameManager.gm.bestTime)
        {
            overUI.transform.GetChild(2).GetComponent<Text>().text = "Your Best Time \n<size=55>" + GetTimeString(GameManager.gm.playTime) + "</size>";
            GameManager.gm.SetBestTime();
        }
        else
        {
            overUI.transform.GetChild(2).GetComponent<Text>().text = "Your Best Time \n<size=55>" + GetTimeString(GameManager.gm.bestTime) + "</size>";
        }
    }
}
