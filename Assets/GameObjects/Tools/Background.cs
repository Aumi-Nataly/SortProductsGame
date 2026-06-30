using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private SpriteRenderer _sr;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        FitToCamera();
    }

    void FitToCamera()
    {
        //if (mainCamera == null) 
        //    mainCamera = Camera.main;

        //float camHeight = mainCamera.orthographicSize * 2f;
        //float camWidth = camHeight * mainCamera.aspect;

        //float spriteHeight = _sr.sprite.rect.height / _sr.sprite.pixelsPerUnit;
        //float scaleY = camHeight / spriteHeight;
        //float scaleX = scaleY; 

        //transform.localScale = new Vector3(scaleX, scaleY, 1f);

        if (mainCamera == null)
            mainCamera = Camera.main;

        float camHeight = mainCamera.orthographicSize * 2f;
        float camWidth = camHeight * mainCamera.aspect;

        float spriteHeight = _sr.sprite.rect.height / _sr.sprite.pixelsPerUnit;
        float spriteWidth = _sr.sprite.rect.width / _sr.sprite.pixelsPerUnit;

        float scaleX = camWidth / spriteWidth;
        float scaleY = camHeight / spriteHeight;

        // Берём больший масштаб, чтобы фон перекрыл весь экран
        float scale = Mathf.Max(scaleX, scaleY);

        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
