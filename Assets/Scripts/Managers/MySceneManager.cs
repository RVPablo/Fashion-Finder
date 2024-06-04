using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class MySceneManager : MonoBehaviour
{
    public bool isAnimating;

    public StartPoint[] startPos;
    public SpawnPoint[] spawnPoint;
    public GridBasedMovement player;

    private FadeInOutScreen fadeInOutScreen;

    private void Awake()
    {
        fadeInOutScreen = FindObjectOfType<FadeInOutScreen>();
    }

    private void Start()
    {
        StartCoroutine(Setup());
    }

    public IEnumerator Setup()
    {
        fadeInOutScreen.ShowScreenNoDelay();

        if (player.playerData.newPos == "" || player.playerData.newPos == null)
        {
            var pos = startPos[Random.Range(0, startPos.Length-1)];
            player.transform.position = pos.transform.position;

            yield return new WaitForSeconds(0.5f);

            yield return fadeInOutScreen.FadeOut();
            isAnimating = false;
        }
        else
        {
            player.canMove = false;
            for (int i  = 0; i < spawnPoint.Length;i++)
            {
                if (spawnPoint[i].name == player.playerData.newPos)
                {
                    player.transform.position = spawnPoint[i].transform.position;
                }
            }

            yield return new WaitForSeconds(0.5f);

            yield return fadeInOutScreen.FadeOut();
            isAnimating = false;
            player.playerData.newPos = "";
            player.canMove = true;
        }

    }

    public IEnumerator LoadScene(string sceneName)
    {
        isAnimating = true;
        yield return fadeInOutScreen.FadeIn();

        yield return new WaitUntil(() => fadeInOutScreen.IsFadeOn);

        SceneManager.LoadSceneAsync(sceneName);
    }
}
