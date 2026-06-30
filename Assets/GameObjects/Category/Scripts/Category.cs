using UnityEngine;

public class Category : MonoBehaviour
{
    [SerializeField]
    private GameObject managerUIobj;

    [SerializeField]
    private int AddScore;
   
    [SerializeField]
    private int MinusScore;

    private ProductType Tag;
    private ManagerUI managerUI;

    private void Start()
    {
        managerUI = managerUIobj.GetComponent<ManagerUI>();
    }


    public void SetTags(ProductType tag)
    {
        Tag = tag;
    }

    public void MatchProduct(Product product)
    { 
        var match = product.GetTags().Contains(Tag);

        if (match)
        {
            SoundManager.Instance.PlayGoodSource();
            managerUI.ChangeScore(AddScore);
            product.DeleteProduct();
        }
        else 
        {
            SoundManager.Instance.PlayBadSource();
            managerUI.ChangeScore(MinusScore);
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
