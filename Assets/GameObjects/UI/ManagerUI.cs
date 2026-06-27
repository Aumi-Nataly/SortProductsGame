using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text currentText;
    [SerializeField] 
    private float timerDuration = 60f;
    [SerializeField] 
    private TMP_Text timerText;
    [SerializeField]
    private GameObject winPanel;

    public event Action OnTimerFinished;
    
    private int SumScore = 0;
    private float remainingTime;

    void Start()
    {
        remainingTime = timerDuration;
  
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

        if(SumScore >= 100)
         winPanel.SetActive(true);
    }
}
