using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChange : MonoBehaviour
{
    public int index = 0;
    public float duration = 1.5f;
    float time = 0;
    Text textColor;

    // Start is called before the first frame update
    void Start()
    {
        textColor = UIManager.um.startUI.transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        time += Time.deltaTime / duration;

        if(index == 0)
        {
            textColor.color = Color.Lerp(new Color(1, 0, 0), new Color(1, 0, 1), time);
        }
        else if (index == 1)
        {
            textColor.color = Color.Lerp(new Color(1, 0, 1), new Color(0, 0, 1), time);
        }
        else if (index == 2)
        {
            textColor.color = Color.Lerp(new Color(0, 0, 1), new Color(0, 1, 1), time);
        }
        else if (index == 3)
        {
            textColor.color = Color.Lerp(new Color(0, 1, 1), new Color(0, 1, 0), time);
        }
        else if (index == 4)
        {
            textColor.color = Color.Lerp(new Color(0, 1, 0), new Color(1, 1, 0), time);
        }
        else if (index == 5)
        {
            textColor.color = Color.Lerp(new Color(1, 1, 0), new Color(1, 0, 0), time);
        }

        if(time >= 1)
        {
            time = 0;
            if (index < 5) index++;
            else index = 0;
        }

    }

}
