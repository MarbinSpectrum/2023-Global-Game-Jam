using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalData : MonoBehaviour
{

    void CheckAnimalNumber(int animalNumber)
    {
        switch (animalNumber)
        {
            case 101:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                break;
            case 102:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                break;
            case 103:
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 2.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                CreateTile(new Vector2(2.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 2.0f));
                break;
            case 201:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                break;
            case 202:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 2.0f));
                break;
            case 203:
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 2.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                CreateTile(new Vector2(2.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 2.0f));
                CreateTile(new Vector2(3.0f, 0.0f));
                CreateTile(new Vector2(3.0f, 1.0f));
                break;
            case 301:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                break;
            case 302:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 2.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                CreateTile(new Vector2(2.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 2.0f));
                CreateTile(new Vector2(3.0f, 0.0f));
                CreateTile(new Vector2(3.0f, 1.0f));
                break;
            case 404:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 1.0f));
                break;
            case 405:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                CreateTile(new Vector2(2.0f, 1.0f));
                CreateTile(new Vector2(3.0f, 1.0f));
                break;
            case 501:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(0.0f, 3.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 2.0f));
                CreateTile(new Vector2(1.0f, 3.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                CreateTile(new Vector2(2.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 2.0f));
                CreateTile(new Vector2(2.0f, 3.0f));
                CreateTile(new Vector2(3.0f, 0.0f));
                CreateTile(new Vector2(3.0f, 1.0f));
                CreateTile(new Vector2(3.0f, 2.0f));
                CreateTile(new Vector2(3.0f, 3.0f));
                CreateTile(new Vector2(4.0f, 0.0f));
                CreateTile(new Vector2(4.0f, 1.0f));
                CreateTile(new Vector2(4.0f, 2.0f));
                CreateTile(new Vector2(4.0f, 3.0f));
                break;
            case 601:
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(0.0f, 3.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 3.0f));
                CreateTile(new Vector2(2.0f, 2.0f));
                CreateTile(new Vector2(2.0f, 3.0f));
                CreateTile(new Vector2(3.0f, 1.0f));
                CreateTile(new Vector2(3.0f, 2.0f));
                break;
            case 602:
                CreateTile(new Vector2(0.0f, 0.0f));
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(0.0f, 3.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 3.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                CreateTile(new Vector2(3.0f, 0.0f));
                CreateTile(new Vector2(3.0f, 1.0f));
                CreateTile(new Vector2(3.0f, 2.0f));
                CreateTile(new Vector2(3.0f, 3.0f));
                break;
            case 603:
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(0.0f, 3.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 1.0f));
                CreateTile(new Vector2(1.0f, 3.0f));
                CreateTile(new Vector2(2.0f, 3.0f));
                break;
            case 604:
                CreateTile(new Vector2(0.0f, 1.0f));
                CreateTile(new Vector2(0.0f, 2.0f));
                CreateTile(new Vector2(0.0f, 3.0f));
                CreateTile(new Vector2(1.0f, 0.0f));
                CreateTile(new Vector2(1.0f, 3.0f));
                CreateTile(new Vector2(2.0f, 0.0f));
                CreateTile(new Vector2(2.0f, 1.0f));
                CreateTile(new Vector2(2.0f, 2.0f));
                CreateTile(new Vector2(2.0f, 3.0f));
                break;
        }
    }

    void CreateTile(Vector2 pos)
    {

    }
}
