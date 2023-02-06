using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    public Vector3 offset;
    public Transform target;
    public float cameraSize;
    public float duration = 0.5f;
    public CameraFit cameraFit;


    private void Start()
    {
        StartCoroutine(moveTargetPos());
    }

    private IEnumerator moveTargetPos()
    {
        Vector2 from = transform.position;
        Vector2 to = target.position + offset;
        float fromSize = camera.orthographicSize;
        float toSize = cameraSize;
        toSize = cameraSize*cameraFit.cameraRate;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.smoothDeltaTime; 
            Vector2 lerp = Vector2.Lerp(from, to, elapsed / duration);
            transform.position = new Vector3(lerp.x, lerp.y, -10);

            float fLerp = Mathf.Lerp(fromSize, toSize, elapsed / duration);
            camera.orthographicSize = fLerp;
            yield return null;
        }

        transform.position = new Vector3(to.x, to.y, -10);
        camera.orthographicSize = toSize;

        StartCoroutine(moveTargetPos());
    }

}
