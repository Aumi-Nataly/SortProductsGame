using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    private void Start()
    {
        var a = UserProfile.GetNumberCurrentLevel();
        Debug.Log($"cur level = {a}");
    }
    public void OnExitButtonClicked()
    {
       
#if UNITY_ANDROID && !UNITY_EDITOR
        // Android: сворачиваем приложение вместо жёсткого выхода
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("moveTaskToBack", true);
#else
        // ПК и редактор: обычный выход
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
#endif
    }

    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
