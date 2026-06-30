using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour, IRestartable
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
    [SerializeField]
    private List<GameObject> objectForResrart;


    public event Action OnTimerFinished;
    
    private int SumScore = 0;
    private float remainingTime; 
    private List<IRestartable> _restartables;



    void Start()
    {
        RestartModulesList();
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

    private void RestartModulesList()
    {
        _restartables = new List<IRestartable>();
        _restartables.Add(this);

        foreach (var obj in objectForResrart)
        {
            _restartables.Add(obj.GetComponent<IRestartable>());
        }
    }

    public void ChangeScore(int score)
    {
        SumScore = SumScore + score < 0 ? 0 : SumScore + score;

        currentText.text = SumScore.ToString();
    }

    private void ShowNotification()
    {

        if (SumScore >= goalScore)
        {
            UserProfile.SaveNextNumberLevel();
            winPanel.SetActive(true);
        }
        else
            defeatPanel.SetActive(true);
        
    }

    public void OnExitButtonClicked()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
        }
#else
        Debug.Log("Выход работает только на Android устройстве");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
#endif
    }

    public void OnNextLevelButtonClicked()
    {
        foreach (var restartable in _restartables)
        {
            restartable.RestartLevel();
        }
    }

    public void RestartLevel()
    {
        Debug.Log("RestartLevel ManagerUI");
        winPanel.SetActive(false);
        defeatPanel.SetActive(false);
        SumScore = 0;
        currentText.text = SumScore.ToString();
        remainingTime = timerDuration;
        Time.timeScale = 1f;
    }
}
