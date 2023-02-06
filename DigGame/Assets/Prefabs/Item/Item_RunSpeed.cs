using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_RunSpeed : Item
{
    public int setTime;
    public SoundObj soundObj;
    public override void runItemEffect()
    {
        GameManager gameManager = GameManager.instance;
        gameManager.speedUpTime = setTime;
        soundObj.RunSE();
    }
}
