using System.Collections.Generic;
using UnityEngine;

public class SpawnerProduct : MonoBehaviour
{
    [SerializeField]
    private int PoolSize = 100;

    [SerializeField]
    private GameObject ProductPrefab;


    private Pool pool;

    private void Awake()
    {
        pool = new Pool(ProductPrefab, PoolSize);
    }

    private void Start()
    {
        SeeProduct();
    }

    private void SeeProduct()
    {
        List<ProductType> tags = new List<ProductType>();


        var product = pool.GetFromPool();
        product.transform.position = transform.position;

        var productModel = product.GetComponent<Product>();
        productModel.SetTags(tags);
        productModel.OnProductToPool += ReturnToPool;


        var spt = product.GetComponent<SpriteRenderer>();
        spt.sprite = Resources.Load<Sprite>("Image/Products/icons8-мандарин-100");

    }

    private void ReturnToPool(GameObject product)
    {
        var productModel = product.GetComponent<Product>();
        productModel.OnProductToPool -= ReturnToPool;

        pool.ReturnToPool(product);
    }
}
