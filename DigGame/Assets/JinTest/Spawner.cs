using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public PoolManager poolManager;
    public Transform[] seat; // 위치 이동ㅇ-

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






    public void DuringClick()  // 오브젝트 클릭되는 상황이면 호출되게 해주세요옹
    {
        if (isClickNow)//클릭중이면
        {
            // 잠깐 오브젝트 안보이게


        }
        else if (!isClickNow)
        {


            // 오브젝트 다시 보이도록
        }


    }


    public void NextAnimal() // 동물 배치하고 집 지어지면 호출할것 ! 
    {

        NowAnimalID = NextAnimalID; //2번째 친구 첫번째로 아이디 옮기기 
        Animal animalNoW = poolManager.GetComponentInChildren<Animal>(); //ㄷㅜㅂㅓㄴㅉㅐ ㅊㅣㄴㄱㅜ ㅊㅏㅈㄱㅣ
        animalNoW.transform.position = seat[0].transform.position; // 두번째 친구 첫번째로 자리 옮기
        DialogueNow = animalNoW.Dialogue;


        Spawn();// 두번째 친구 자리에 새롭게 새 친구 부르

        print("얍");

    }


    public void Spawn()

    {
        int num = Random.Range(0, 12);
        GameObject animal = poolManager.Get(num);
        animal.transform.position = seat[1].transform.position;
    }








}
