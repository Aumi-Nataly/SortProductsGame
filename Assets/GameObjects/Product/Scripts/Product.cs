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

    public List<ProductType> GetTags() => Tag;

    public void DeleteProduct()
    {
        Debug.Log("DeleteProduct");
        OnProductToPool?.Invoke(gameObject);
    }

}
