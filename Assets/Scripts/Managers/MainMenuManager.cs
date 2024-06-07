using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenuManager : MonoBehaviour
{
    public string[] allScenes;
    public SceneData[] sceneData;
    public PlayerData playerData;
    public AudioMixer audioMixer;
    [SerializeField] Slider slider;

    public void GetRandomScene()
    {
        var choosenStartScene = allScenes[UnityEngine.Random.Range(0, allScenes.Length)];

        foreach (var sceneData in sceneData)
        {
            sceneData.Reset();
        }

        playerData.Reset();

        RandomTheme(playerData);
        SceneManager.LoadSceneAsync(choosenStartScene);
    }

    private void Start()
    {
        audioMixer.SetFloat("volume", playerData.volume);
        slider.value = playerData.volume;
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

    public void RandomTheme(PlayerData playerData)
    {
        System.Random rand = new System.Random();

        int randomNumber = rand.Next(1, 4);

        if (randomNumber == 1)
        {
            playerData.Theme = ClothStyles.Chic;
        } else if (randomNumber == 2)
        {
            playerData.Theme= ClothStyles.Formal;
        } else if (randomNumber == 3)
        {
            playerData.Theme = ClothStyles.Unformal;
        }
    }
}
