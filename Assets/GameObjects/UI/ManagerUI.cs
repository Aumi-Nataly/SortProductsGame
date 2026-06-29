using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text currentText;
    [SerializeField]
    private TMP_Text goalText;
    [SerializeField] 
    private float timerDuration = 60f;
    [SerializeField] 
    private TMP_Text timerText;
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject defeatPanel; 
    [SerializeField]
    private int goalScore = 100;

    public event Action OnTimerFinished;
    
    private int SumScore = 0;
    private float remainingTime;

    void Start()
    {
        remainingTime = timerDuration;
        goalText.text = "Цель: " + goalScore.ToString();
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;

            Time.timeScale = 0f;           // ставим паузу
            ShowNotification();   
            OnTimerFinished?.Invoke();    // оповещение
            return;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }

    public void ChangeScore(int score)
    {
        SumScore = SumScore + score < 0 ? 0 : SumScore + score;

        currentText.text = SumScore.ToString();
    }

    private void ShowNotification()
    {
        Debug.Log("Время вышло!");

       if( SumScore >= goalScore)
            winPanel.SetActive(true);
        else
            defeatPanel.SetActive(true);
        
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
}
