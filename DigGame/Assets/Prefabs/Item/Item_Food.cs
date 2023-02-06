using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Food : Item
{
    public override void runItemEffect()
    {
        GameManager gameManager = GameManager.instance;
        gameManager.getFood = true;
    }
}
