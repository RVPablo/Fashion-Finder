using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string[] allScenes;

    public void GetRandomScene()
    {
        var choosenStartScene = allScenes[Random.Range(0, allScenes.Length)];

        SceneManager.LoadSceneAsync(choosenStartScene);
    }
}
