using System;
using System.Collections.Generic;
using UnityEngine;
public class Product : MonoBehaviour
{

    public event Action<GameObject> OnProductToPool;

    private List<ProductType> Tag;

    public void SetTags(List<ProductType> tags)
    {
        Tag = tags;
    }


    public void DeleteProduct()
    {
        OnProductToPool?.Invoke(gameObject);
    }

}
