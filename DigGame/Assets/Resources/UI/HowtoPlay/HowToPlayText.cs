using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HowToPlayText : MonoBehaviour
{

    public TextMeshProUGUI PASS_BTN;
    public TextMeshProUGUI HOWTOPLAY_DIAOGUE;
    public TextMeshProUGUI HOWTOPLAY_TEXT0;
    public TextMeshProUGUI HOWTOPLAY_TEXT1;
    public TextMeshProUGUI HOWTOPLAY_TEXT2;
    public TextMeshProUGUI HOWTOPLAY_TEXT3;
    public TextMeshProUGUI HOWTOPLAY_TEXT4;
    public TextMeshProUGUI HOWTOPLAY_TEXT5;
    public TextMeshProUGUI HOWTOPLAY_TEXT6;
    public TextMeshProUGUI HOWTOPLAY_TEXT7;
    public TextMeshProUGUI HOWTOPLAY_TEXT8;
    public TextMeshProUGUI HOWTOPLAY_TEXT9;
    public TextMeshProUGUI HOWTOPLAY_TEXT10;

    private void Update()
    {


        PASS_BTN.text = LanguageManager.GetText("PASS_BTN");
        HOWTOPLAY_DIAOGUE.text = LanguageManager.GetText("HOWTOPLAY_DIAOGUE");
        HOWTOPLAY_TEXT0.text = LanguageManager.GetText("HOWTOPLAY_TEXT0");
        HOWTOPLAY_TEXT1.text = LanguageManager.GetText("HOWTOPLAY_TEXT1");
        HOWTOPLAY_TEXT2.text = LanguageManager.GetText("HOWTOPLAY_TEXT2");
        HOWTOPLAY_TEXT3.text = LanguageManager.GetText("HOWTOPLAY_TEXT3");
        HOWTOPLAY_TEXT4.text = LanguageManager.GetText("HOWTOPLAY_TEXT4");
        HOWTOPLAY_TEXT5.text = LanguageManager.GetText("HOWTOPLAY_TEXT5");
        HOWTOPLAY_TEXT6.text = LanguageManager.GetText("HOWTOPLAY_TEXT6");
        HOWTOPLAY_TEXT7.text = LanguageManager.GetText("HOWTOPLAY_TEXT7");
        HOWTOPLAY_TEXT8.text = LanguageManager.GetText("HOWTOPLAY_TEXT8");
        HOWTOPLAY_TEXT9.text = LanguageManager.GetText("HOWTOPLAY_TEXT9");
        HOWTOPLAY_TEXT10.text = LanguageManager.GetText("HOWTOPLAY_TEXT10");



    }

    public void GameStart()
    {
        GameManager.instance.GameStart();
        gameObject.SetActive(false);
    }
}
