using UnityEngine;

public class ProductToTrash : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        var product = other.GetComponent<Product>();
        if (product != null)
        {
            Debug.Log($"✅ Поймали предмет: ");
            product.DeleteProduct();
        }

    }
}
