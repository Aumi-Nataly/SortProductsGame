using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerProduct : MonoBehaviour
{
    [SerializeField]
    private int PoolSize = 10;

    [SerializeField]
    private GameObject ProductPrefab;


    private Pool pool;
    private ReaderJson<ProductDataList> reader;
    private ProductDataList productDataList;

    private void Awake()
    {
        pool = new Pool(ProductPrefab, PoolSize);
        reader = new ReaderJson<ProductDataList>("products.json");
    }

    private async UniTaskVoid Start()
    {
        productDataList = await reader.ReaderJsonDataAsync();
        SeeProduct();
    }

    private void SeeProduct()
    {
        List<ProductType> tags = new List<ProductType>();


        var product = pool.GetFromPool();
        product.transform.position = transform.position;

        var prData = GetRandomProduct();

        var productModel = product.GetComponent<Product>();
        productModel.SetTags(prData.Tag);
        productModel.OnProductToPool += ReturnToPool;


        var spt = product.GetComponent<SpriteRenderer>();
        spt.sprite = Resources.Load<Sprite>($"Image/Products/{prData.ImageName}");

    }

    private ProductData GetRandomProduct()
    {
        int count = productDataList.Products.Count;
        int randomNumber = UnityEngine.Random.Range(1, count + 1);

        ProductData pr = productDataList.Products.Where(x => x.Id == randomNumber).FirstOrDefault();
        return pr;
    }


    private void ReturnToPool(GameObject product)
    {
        var productModel = product.GetComponent<Product>();
        productModel.OnProductToPool -= ReturnToPool;

        pool.ReturnToPool(product);
        SeeProduct();
    }

    
}
