using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ending : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject DialogueBG;
    public GameObject Dialogue1;
    public GameObject Dialogue2;
    public TextMeshProUGUI ending001;
    public TextMeshProUGUI ending002;

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

    public BGM_Player endBGM;

    public void StartEnding()
    {
        StartCoroutine(runStartEnding());
    }

    private IEnumerator runStartEnding()
    {
        endBGM.RunBGM();
        //Destroy(poolManager.nowAnimal);

        poolManager.DestroyNowAnimal();

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

        endingHouse.SetActive(true);
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
        yield return new WaitForSeconds(1f);
        normalHouse.SetActive(false);
        yield return new WaitForSeconds(7f);
        DialogueBG.SetActive(true);
        Dialogue2.SetActive(false);
        string Formatvalue = LanguageManager.GetText("ENDING_001");
        ending001.text = string.Format(LanguageManager.GetText("ENDING_001"), GameManager.instance.killCnt);
        ending002.text = LanguageManager.GetText("ENDING_002");

        yield return new WaitForSeconds(5f);


        Dialogue1.SetActive(false);
        Dialogue2.SetActive(true);
     

    }
}
