using UnityEngine;

public static class UserProfile
{
    private const string KeyCurrentLevel = "current_level";
    private const int maxLevel = 4;

    public static int GetNumberCurrentLevel()
    {
       return PlayerPrefs.GetInt(KeyCurrentLevel, 1);
    }

    public static void SaveNextNumberLevel()
    {
        int cur = PlayerPrefs.GetInt(KeyCurrentLevel, 1); 

        // Вычисляем следующий уровень по кругу
        int next = cur < maxLevel ? cur + 1 : 1;

        PlayerPrefs.SetInt(KeyCurrentLevel, next);
        PlayerPrefs.Save();
    }
    public static void TestNumberLevel()
    {
        PlayerPrefs.SetInt(KeyCurrentLevel, 1);
        PlayerPrefs.Save();
    }
}
