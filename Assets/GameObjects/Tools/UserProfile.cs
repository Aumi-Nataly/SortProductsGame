using UnityEngine;

public static class UserProfile
{
    private const string KeyCurrentLevel = "current_level";

    public static int GetNumberCurrentLevel()
    {
       return PlayerPrefs.GetInt(KeyCurrentLevel, 1);
    }

    public static void SaveNextNumberLevel()
    {
        int cur = PlayerPrefs.GetInt(KeyCurrentLevel, 1);
        cur = cur == 4 ? 0 : cur; //для запуска уровней по кругу

        PlayerPrefs.SetInt(KeyCurrentLevel, cur + 1);
        PlayerPrefs.Save();
    }
}
