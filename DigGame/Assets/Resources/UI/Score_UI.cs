using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_UI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private void Update()
    {
        int score = GameManager.instance.score;
        scoreText.text = string.Format("{0:D6}", score);
    }
}
