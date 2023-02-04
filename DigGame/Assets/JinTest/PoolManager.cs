using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹들을 보관할 변수
    public GameObject[] prefabs; // 동물1~~ 

    // 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    Animal animal;

    public int NowAnimalNum;
    public int NextAnimalNum;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }


    }


    private void Update()
    {




    }




    // 게임 오브젝트를 반환하는 함수
    public GameObject Get(int typeNum)
    {
        GameObject select = null;
        NowAnimalNum = NextAnimalNum;
        NextAnimalNum = typeNum;

        if (select == null)
        {
            select = Instantiate(prefabs[typeNum], transform); // poll매니저 안에다 자식으로 생성
            pools[typeNum].Add(select);
        }
        return select;
    }


    public void animalSetting()
    {

        Vector3 mPosition = Input.mousePosition; //마우스 스크린 좌표
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        //Animal animal = 
        Instantiate(prefabs[1], target, Quaternion.identity);


    }


}



