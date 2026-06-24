using DG.Tweening;
using UnityEngine;

public class ProductAnimator : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(new Vector3(2, 2, 1), 1f);
    }
}
