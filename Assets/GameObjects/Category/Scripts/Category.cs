using System.Collections.Generic;
using UnityEngine;

public class Category : MonoBehaviour
{
    private ProductType Tag;

    public void SetTags(ProductType tag)
    {
        Tag = tag;
    }

    public void MatchProduct(Product product)
    { 
        var match = product.GetTags().Contains(Tag);

        if (match)
        {
            Debug.Log("Категория совпала");
            product.DeleteProduct();
        }
        else 
        {
            Debug.Log("Категория НЕ совпала");
            product.DeleteProduct();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var product = other.GetComponent<Product>();
        if (product != null)
        {
            MatchProduct(product);
        }

    }
}
