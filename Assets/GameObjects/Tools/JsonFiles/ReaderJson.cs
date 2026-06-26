using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.Networking;

public class ReaderJson <T> where T : class
{  
    private readonly string _savePath;

    public ReaderJson(string fileName = "products.json")
    {
        _savePath = Path.Combine(Application.streamingAssetsPath, fileName); 
    }

    /// <summary>
    /// Асинхронная загрузка данных через UniTask. Работает на всех платформах.
    /// </summary>
    public async UniTask<T> ReaderJsonDataAsync(CancellationToken cancellationToken = default)
    {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_MAC
        // Для ПК/редактора 
        if (System.IO.File.Exists(_savePath))
        {
            string json = System.IO.File.ReadAllText(_savePath);
            return JsonUtility.FromJson<T>(json);
        }
        else
        {
            Debug.LogWarning($"Файл не найден (ПК режим): {_savePath}");
            return null;
        }
#else
        // Для мобильных: только через UnityWebRequest
        using (var request = UnityWebRequest.Get(_savePath))
        {
            await request.SendWebRequest().ToUniTask(cancellationToken: cancellationToken);

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                return JsonUtility.FromJson<T>(json);
            }
            else
            {
                Debug.LogError($"Ошибка загрузки JSON: {request.error} | URL: {_savePath}");
                return null;
            }
        }
#endif
    }

}
