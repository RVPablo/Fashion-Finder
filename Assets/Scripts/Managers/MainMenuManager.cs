using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public string[] allScenes;
    public SceneData[] sceneData;
    public PlayerData playerData;

    public AudioMixer audioMixer;
    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;

    public void GetRandomScene()
    {
        var choosenStartScene = allScenes[Random.Range(0, allScenes.Length)];

        foreach (var sceneData in sceneData)
        {
            sceneData.Reset();
        }

        playerData.Reset();

        SceneManager.LoadSceneAsync(choosenStartScene);
    }

    private void Start()
    {
        audioMixer.SetFloat("volume", playerData.volume);
        slider.value = playerData.volume;
        toggle.isOn = playerData.IsCensored;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        playerData.volume = volume;
    }

    public void SetCensorship(Toggle toggle)
    {
        playerData.IsCensored = toggle.isOn;
    }
}
