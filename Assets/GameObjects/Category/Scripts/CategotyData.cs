using System;
using System.Collections.Generic;

[System.Serializable]
public class CategotyData
{
    public int Id;
    public string ImageName;
    public ProductType Tag;
    public int[] LevelId;
}

[Serializable]
public class CategotyDataList
{
    public List<CategotyData> Categories;
}