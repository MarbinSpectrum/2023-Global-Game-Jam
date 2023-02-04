using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar_UI : MonoBehaviour
{
    [SerializeField]
    private Image bar;

    private void Update()
    {
        GameManager gameManager = GameManager.instance;
        int curTime = gameManager.curTime;
        int startTime = gameManager.startTime;
        float value = (float)(startTime - curTime) / (float)startTime;
        bar.fillAmount = value;
    }
}
