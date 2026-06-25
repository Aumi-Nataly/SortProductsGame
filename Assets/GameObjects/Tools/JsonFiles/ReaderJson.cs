
using System.IO;
using UnityEngine;

public class ReaderJson
{  
    private  string _savePath = Path.Combine(Application.streamingAssetsPath, "products.json");
    public ProductDataList ReaderJsonData()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            ProductDataList loadedData = JsonUtility.FromJson<ProductDataList>(json);
            return loadedData;
        }
        else
        {
            Debug.LogWarning("Файл не найден!" + _savePath);
            return null;
        }
    }

}
