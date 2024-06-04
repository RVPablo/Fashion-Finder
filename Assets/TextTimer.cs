using UnityEngine;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour
{
    public Text timerText;
    public float duration = 10f; 

    private float timeRemaining;
    private bool timerRunning = false;

    void Start()
    {
        if (timerText != null)
        {
            timeRemaining = duration;
            timerRunning = true;
        }
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText(timeRemaining);
            }
            else
            {
                Debug.Log("Timer terminé!");
                timeRemaining = 0;
                timerRunning = false;
                UpdateTimerText(timeRemaining);
            }
        }
    }

    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
