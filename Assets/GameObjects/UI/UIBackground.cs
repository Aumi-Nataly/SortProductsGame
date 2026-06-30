using UnityEngine;

public class UIBackground : MonoBehaviour
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

        if (_safeArea.Equals(r)) 
                return;

        _safeArea = r;

        var emptySquare = Screen.height - Screen.safeArea.height;
        _rect.sizeDelta = new Vector2(_rect.sizeDelta.x, emptySquare);
     }

}