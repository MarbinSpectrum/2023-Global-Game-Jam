using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public PoolManager poolManager;
    public Transform[] seat; // ��ġ �̵���-

    public int NowAnimalID = 0;
    public int NextAnimalID;
    public string DialogueNow;



    public bool isClickNow = false;


    //public List[] Line;


    void Start()
    {
        int StartSetAnimal = Random.Range(0, 12);
        GameObject animal1 = poolManager.Get(StartSetAnimal);
        animal1.transform.position = seat[0].transform.position;


        int StartSetAnima2 = Random.Range(0, 12);
        GameObject animal2 = poolManager.Get(StartSetAnima2);
        animal2.transform.position = seat[1].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            NextAnimal();
        }


        DuringClick();

    }






    public void DuringClick()  // ������Ʈ Ŭ���Ǵ� ��Ȳ�̸� ȣ��ǰ� ���ּ����
    {
        if (isClickNow)//Ŭ�����̸�
        {
            // ��� ������Ʈ �Ⱥ��̰�


        }
        else if (!isClickNow)
        {


            // ������Ʈ �ٽ� ���̵���
        }


    }


    public void NextAnimal() // ���� ��ġ�ϰ� �� �������� ȣ���Ұ� ! 
    {

        NowAnimalID = NextAnimalID; //2��° ģ�� ù��°�� ���̵� �ű�� 
        Animal animalNoW = poolManager.GetComponentInChildren<Animal>(); //���̤��ä����� ���Ӥ����� ����������
        animalNoW.transform.position = seat[0].transform.position; // �ι�° ģ�� ù��°�� �ڸ� �ű�
        DialogueNow = animalNoW.Dialogue;


        Spawn();// �ι�° ģ�� �ڸ��� ���Ӱ� �� ģ�� �θ�

        print("��");

    }


    public void Spawn()

    {
        int num = Random.Range(0, 12);
        GameObject animal = poolManager.Get(num);
        animal.transform.position = seat[1].transform.position;
    }








}
