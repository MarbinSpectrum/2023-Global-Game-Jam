using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CanvasScale : MonoBehaviour
{
    public CanvasScaler canvasScaler;
    public float baseWidth;
    public float baseHeight;

    private void Update()
    {

        float height = Screen.height;
        float width = Screen.width;

        if(baseWidth/baseHeight > width / height)
            canvasScaler.matchWidthOrHeight = 0;
        else
            canvasScaler.matchWidthOrHeight = 1;
    }
}
