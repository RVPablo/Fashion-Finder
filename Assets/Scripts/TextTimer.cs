using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextTimer : MonoBehaviour
{
    public Text timerText;
    public float duration = 60f;
    public string sceneName;  // Assurez-vous que le nom est correct

    private float timeRemaining;
    private bool timerRunning = false;

    public float TimeRemaining { get { return timeRemaining; } }

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
                ChangeScene();
            }
        }
    }

    public void Stop()
    {
        timerRunning = false;
    }

    public void Resume()
    {
        timeRemaining = duration;
        UpdateTimerText(duration);
        timerRunning=true;
    }

    public void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);  
    }
}
