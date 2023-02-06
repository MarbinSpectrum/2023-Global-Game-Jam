using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Time : Item
{
    public int addTime;
    public SoundObj soundObj;
    public override void runItemEffect()
    {
        GameManager gameManager = GameManager.instance;
        gameManager.AddTime(addTime);
        soundObj.RunSE();
    }
}
