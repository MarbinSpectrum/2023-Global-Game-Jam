using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �����յ��� ������ ����
    public GameObject[] prefabs; // ����1~~ 

    // Ǯ ����� �ϴ� ����Ʈ��
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




    // ���� ������Ʈ�� ��ȯ�ϴ� �Լ�
    public GameObject Get(int typeNum)
    {
        GameObject select = null;
        NowAnimalNum = NextAnimalNum;
        NextAnimalNum = typeNum;

        if (select == null)
        {
            select = Instantiate(prefabs[typeNum], transform); // poll�Ŵ��� �ȿ��� �ڽ����� ����
            pools[typeNum].Add(select);
        }
        return select;
    }


    public void animalSetting()
    {

        Vector3 mPosition = Input.mousePosition; //���콺 ��ũ�� ��ǥ
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        //Animal animal = 
        Instantiate(prefabs[1], target, Quaternion.identity);


    }


}



