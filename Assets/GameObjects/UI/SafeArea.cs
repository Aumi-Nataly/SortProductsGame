using UnityEngine;

public class SafeArea : MonoBehaviour
{

    private RectTransform _rect;
    private Rect _safeArea;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        // область без вырезов
        var r = Screen.safeArea;

        if(Screen.height == Screen.safeArea.height)
            return;


        if (_safeArea.Equals(r)) 
            return;

        _safeArea = r;

        //// Перевод координат экрана в нормализованные (0–1)
        //Vector2 min = new Vector2(r.xMin / Screen.width, r.yMin / Screen.height);
        //Vector2 max = new Vector2(r.xMax / Screen.width, r.yMax / Screen.height);

        //_rect.anchorMin = min;
        //_rect.anchorMax = max;

      
        var topInset = Screen.height - Screen.safeArea.height - 10f;
       _rect.offsetMax = new Vector2(_rect.offsetMax.x, -topInset);

    }

}
