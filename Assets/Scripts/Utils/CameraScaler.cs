using UnityEngine;
using EventManager;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraScaler : MonoBehaviour
{
    public float DesignOrthographicSize = 5;
    public float DesignWidth = 1920;
    public float DesignY = 0;

    Camera _camera;

    void Awake()
    {
        _camera = GetComponent<Camera>();
        _camera.orthographic = true;
    }

    void OnScreenSizeChanged()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        float aspectSscale =  1.77777778f / currentAspect;
        
        float currentWidth = (float)Screen.width;
        float scale = currentWidth / DesignWidth;
        Debug.Log("Scale: " + scale);

        _camera.orthographicSize = DesignOrthographicSize * scale * aspectSscale;
        _camera.transform.position = new Vector3(0, DesignY * scale, -10);
    }

    void Start()
    {
        CustomEventManager.StartListening(CustomEventType.ScreenSizeChanged, OnScreenSizeChanged);
        OnScreenSizeChanged();
    }
}