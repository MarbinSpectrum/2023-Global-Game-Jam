using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject DialogueBG;
    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public Text Count;

    public GameManager gameManager;
    public PoolManager poolManager;


    public FollowCamera followCamera;
    public Transform closeOutTargetPos;
    public Vector3 closeOutOffset;
    public float closeOutSize;
    public float closeOutDuration;

    public Transform closeUpTargetPos;
    public Vector3 closeUpOffset;
    public float closeUpSize;
    public float closeUpDuration;

    public GameObject moleObj;

    public GameObject normalHouse;
    public GameObject endingHouse;

    public SpriteRenderer blueFilter;

   

    public void StartEnding()
    {
        StartCoroutine(runStartEnding());
    }

    private IEnumerator runStartEnding()
    {
        //Destroy(poolManager.nowAnimal);
       
        poolManager.nowAnimal.GetComponent<AnimalManager>()._clicked = false;
        poolManager.nowAnimal.GetComponent<AnimalManager>().Destroy();


        normalHouse.SetActive(false);
        endingHouse.SetActive(true);
        gameUI.SetActive(false);

        followCamera.target = closeOutTargetPos;
        followCamera.offset = closeOutOffset;
        followCamera.cameraSize = closeOutSize;
        followCamera.duration = closeOutDuration;

        yield return new WaitForSeconds(9f);

        moleObj.SetActive(false);
        followCamera.target = closeUpTargetPos;
        followCamera.offset = closeUpOffset;
        followCamera.cameraSize = closeUpSize;
        followCamera.duration = closeUpDuration;

        yield return new WaitForSeconds(3f);

        float fromA = 0;
        float toA = 1;
        float elapsed = 0.0f;
        while (elapsed < 2f)
        {
            elapsed += Time.smoothDeltaTime;

            float fLerp = Mathf.Lerp(fromA, toA, elapsed / 2f);
            UnityEngine.Color color = blueFilter.color;
            color.a = fLerp;
            blueFilter.color = color;

            yield return null;
        }
        blueFilter.color = new UnityEngine.Color(1, 1, 1, 1);

        yield return new WaitForSeconds(5f);
        DialogueBG.SetActive(true);
        Dialogue2.SetActive(false);
        Count.text = gameManager.killCnt.ToString();


        yield return new WaitForSeconds(5f);


        Dialogue1.SetActive(false);
        Dialogue2.SetActive(true);
     

    }
}
