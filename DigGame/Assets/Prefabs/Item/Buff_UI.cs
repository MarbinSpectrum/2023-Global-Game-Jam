using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_UI : MonoBehaviour
{
    public GameObject food;
    public GameObject digSpeed;
    public GameObject runSpeed;

    private void Update()
    {
        GameManager gameManager = GameManager.instance;
        food.SetActive(gameManager.getFood);
        digSpeed.SetActive(gameManager.digUpTime > 0);
        runSpeed.SetActive(gameManager.speedUpTime > 0);
    }
}
