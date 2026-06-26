using DG.Tweening;
using UnityEngine;

public class ProductAnimator : MonoBehaviour
{
    public void StartAnimation()
    {
        transform.localScale = Vector3.one;
        transform.DOScale(new Vector3(2, 2, 1), 1.5f);
    }
}
