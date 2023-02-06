
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public FollowCamera followCamera;
    public Vector3 targetOffset;
    public Transform target;
    public float cameraSize;
    public float duration;
    public Animation animation;

    public void GameStart()
    {
        StartCoroutine(runGameStart());
    }

    public IEnumerator runGameStart()
    {
        animation.Play();
        followCamera.target = target;
        followCamera.offset = targetOffset;
        followCamera.cameraSize = cameraSize;
        followCamera.duration = duration;

        followCamera.enabled = true;

        yield return new WaitForSeconds(duration);
        followCamera.duration = 0.02f;
        GameManager.instance.GameStart();
    }
}
