using UnityEngine;

//Зафиксировать высоту камеры
public class PortraitCameraSetup : MonoBehaviour
{
    [SerializeField] 
    private float worldHeight = 16f;

    private Camera cam;

    
    private void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;
        cam.orthographicSize = worldHeight / 2f;
    }
}
