
using System;
using System.Collections.Generic;

[Serializable]
public class ProductDataList
{
    public List<ProductData> Products;
}

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
   Fruit, //0
   Red, //1
   Yellow //2
}
