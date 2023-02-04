using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Animal;
using static UnityEngine.GraphicsBuffer;

public class PoolManager : MonoBehaviour
{
   
    public GameObject[] prefabs; // ����1~~ 
    List<GameObject>[] pools;
    Animal animal;

    public int NowAnimalId;
    public int AnimalNum;
    public string DialogueNow;

    // 배열로 넣었다가 졸려서 번호 계속 헷갈려서 일단 따로따 public GameObject catImg;
    public GameObject catImg;
    public GameObject RabbitImg;
    public GameObject TurtleImg;
    public GameObject PuppyImg;
    public GameObject ElephantImg;
    public GameObject SnakeImg;

    public uint CatRate;
    public uint RabbitRate;
    public uint TurtleRate;
    public uint PuppyRate;
    public uint ElephantRate;
    public uint SnakeRate;


    public int[] CurAnimal;

    private void Awake()
    {
        AnimalSetting();
    }



    public void AnimalSetting()
    {
        Alloff();

        Dictionary<AnimalType, int> aniRate = new Dictionary<AnimalType, int>();
        aniRate[AnimalType.Cat] = (int)CatRate;
        aniRate[AnimalType.Rabbit] = (int)RabbitRate;
        aniRate[AnimalType.Turtle] = (int)TurtleRate;
        aniRate[AnimalType.Puppy] = (int)PuppyRate;
        aniRate[AnimalType.Elephant] = (int)ElephantRate;
        aniRate[AnimalType.Snake] = (int)SnakeRate;

        int sum = 0;
        foreach (KeyValuePair<AnimalType, int> aniRatePair in aniRate)
            sum += aniRatePair.Value;

        AnimalType animalType = AnimalType.Cat;
        int r = Random.Range(0, sum);
        foreach (KeyValuePair<AnimalType, int> aniRatePair in aniRate)
        {
            int v = aniRatePair.Value;
            AnimalType key = aniRatePair.Key;
            if (r < v)
            {
                animalType = key;
                break;
            }
            r -= v;
        }

        switch (animalType)
        {
            // 0 : 고양이
            case AnimalType.Cat:
                int cat = Random.Range(0,3);

                if(cat == 0)
                {
                    NowAnimalId = 101;
                    AnimalNum = 0;
                    DialogueNow = " 냐아아앙...";
                }
                else if(cat == 1)
                {
                    NowAnimalId = 102;
                    AnimalNum = 1;
                    DialogueNow = " 스트레칭 할 넓은 공간이 필요하다냥";
                }
                else if(cat == 2)
                {
                    NowAnimalId = 103;
                    AnimalNum = 2;
                    DialogueNow = " 춤을 춰서 추위를 이겨내자냥! ";
                }


                catImg.SetActive(true);


                break;

            // 1 : 토끼 
            case AnimalType.Rabbit:
                int Rabbit = Random.Range(0, 2);

                if (Rabbit == 0)
                {
                    NowAnimalId = 201;
                    AnimalNum = 3;
                    DialogueNow = " 이번 겨울은 너무 추워요";
                }
                else if (Rabbit == 1)
                {
                    NowAnimalId = 202;
                    AnimalNum = 4;
                    DialogueNow = "우리는 둘이 한몸...!";
                }

                RabbitImg.SetActive(true);

                break;

            // 2 : 거북이 
            case AnimalType.Turtle:
                int Turtle = Random.Range(0, 2);

                if (Turtle == 0)
                {
                    NowAnimalId = 301;
                    AnimalNum = 5;
                    DialogueNow = "안....녕.....하세...요....저...는....거...북..";
                }
                else if (Turtle == 1)
                {
                    NowAnimalId = 302;
                    AnimalNum = 6;
                    DialogueNow = "..........거.....북....ㅠ";
                }

                TurtleImg.SetActive(true);

                break;

            // 3  : 강아지 
            case AnimalType.Puppy:

                int Puppy = Random.Range(0, 2);

                if (Puppy == 0)
                {
                    NowAnimalId = 404;
                    AnimalNum = 7;
                    DialogueNow = "고기가 쪼아!";
                }
                else if (Puppy == 1)
                {
                    NowAnimalId = 405;
                    AnimalNum = 8;
                    DialogueNow = "겨울만 지나면 엄마랑 만날거에요 멍!";
                }

                PuppyImg.SetActive(true);

                break;

            // 4 : 코끼5
            case AnimalType.Elephant:
                NowAnimalId = 501;
                ElephantImg.SetActive(true);
                AnimalNum = 9;
                DialogueNow = "나처럼 큰 동물을 위한 집도 가능할까요?";
                break;

            // 5 : 뱀 
            case AnimalType.Snake:
                int Snake = Random.Range(0, 2);

                if (Snake == 0)
                {
                    NowAnimalId = 601;
                    AnimalNum = 10;
                    DialogueNow = "나는 좀 까다롭다구?";
                }
                else if (Snake == 1)
                {
                    NowAnimalId = 602;
                    AnimalNum = 11;
                    DialogueNow = "쉬익... 쉬익...!";
                }
                SnakeImg.SetActive(true);
                break;

           
        }


    }



    public void Alloff() //호출되는 경우 1. 드래그 해서 동물 배치중일때 2. 동물 바뀔Alloff()
    {
        catImg.SetActive(false);
        RabbitImg.SetActive(false);
        TurtleImg.SetActive(false);
        PuppyImg.SetActive(false);
        ElephantImg.SetActive(false);
        SnakeImg.SetActive(false);
    }

    


    //사용하지 않는 함수...... 


    // ���� ������Ʈ�� ��ȯ�ϴ� �Լ�
    public GameObject Get(int typeNum)
    {
        GameObject select = null;
        //NowAnimalNum = NextAnimalNum;
        //NextAnimalNum = typeNum;

        if (select == null)
        {
            select = Instantiate(prefabs[typeNum], transform); // poll�Ŵ��� �ȿ��� �ڽ����� ����
            pools[typeNum].Add(select);
        }
        return select;
    }


    //public void animalSetting()
    //{

    //   Vector3 mPosition = Input.mousePosition; //���콺 ��ũ�� ��ǥ
    //    Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
    //    Instantiate(prefabs[1], target, Quaternion.identity);


    //}



    public void animalclick()
    {
        Vector3 mPosition = Input.mousePosition;
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        Instantiate(prefabs[AnimalNum], target, Quaternion.identity);

    }


}



