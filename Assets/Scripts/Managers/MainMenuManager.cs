using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string[] allScenes;
    public SceneData[] sceneData;
    public PlayerData playerData;

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
}
