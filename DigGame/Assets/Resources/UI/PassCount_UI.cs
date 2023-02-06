using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCount_UI : MonoBehaviour
{
    public GameObject obj0;
    public GameObject obj1;
    public GameObject obj2;

    public void Update()
    {
        PoolManager poolManager = PoolManager.instance;
        if (poolManager == null)
            return;
        int passCnt = poolManager.passCnt;
        if(passCnt >= 3)
        {
            obj0.SetActive(true);
            obj1.SetActive(true);
            obj2.SetActive(true);
        }
        else if (passCnt == 2)
        {
            obj0.SetActive(true);
            obj1.SetActive(true);
            obj2.SetActive(false);
        }
        else if (passCnt == 1)
        {
            obj0.SetActive(true);
            obj1.SetActive(false);
            obj2.SetActive(false);
        }
        else
        {
            obj0.SetActive(false);
            obj1.SetActive(false);
            obj2.SetActive(false);
        }
    }
}
