using UnityEngine;

////////////////////////////////////////////////////////////////////////////////
/// : 해상도에 따른 카메라의 크기를 조정합니다.
////////////////////////////////////////////////////////////////////////////////
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraFit : MonoBehaviour
{
    [SerializeField] private float sceneWidth = 10;
    [SerializeField] private float sceneHeight = 10;
    [SerializeField] private float baseSceneWidth = 1080;
    [SerializeField] private float baseSceneHeight = 1920;
    [SerializeField] private Camera _camera;
    public float baseCameraSize;
    public float cameraSize;
    public float cameraRate;

    private void Update()
    {
        float rate = baseSceneWidth / baseSceneHeight;
        if (rate > (float)Screen.width / (float)Screen.height)
        {
            //높이가 높은 상태
            //너비 기준으로 해상도를 맞춘다.
            float unitsPerPixel = sceneWidth / Screen.width;
            _camera.orthographicSize = unitsPerPixel * Screen.height;
            cameraSize = unitsPerPixel * Screen.height;
            cameraRate = cameraSize / baseCameraSize;
        }
        else
        {
            //너비가 넓은 상태
            //높이 기준으로 해상도를 맞춘다.
            _camera.orthographicSize = sceneHeight;
            cameraSize = sceneHeight;
            cameraRate = cameraSize / baseCameraSize;
        }
    }
}

