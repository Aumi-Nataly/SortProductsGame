
using System.Collections.Generic;


[System.Serializable]
public class ProductData
{
    public int Id;
    public string ImageName;
    public List<ProductType> Tag;
}

[System.Serializable]
public enum ProductType
{
   Fruit,
   Red
}
