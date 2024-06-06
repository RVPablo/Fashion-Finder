using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextTimer : MonoBehaviour
{
    public Text timerText;
    public float duration = 10f;
    public string sceneName = "End";  // Assurez-vous que le nom est correct

    private float timeRemaining;
    private bool timerRunning = false;

    public float TimeRemaining { get { return timeRemaining; } }

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
                ChangeScene();
            }
        }
    }

    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("End");  
    }
}
