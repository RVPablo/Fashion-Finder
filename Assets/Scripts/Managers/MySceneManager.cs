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
    public ClothSpawn[] clothSpawns;
    public GridBasedMovement player;
    public TextTimer timer;

    [SerializeField] SceneData sceneData;

    private FadeInOutScreen fadeInOutScreen;

    private void Awake()
    {
        fadeInOutScreen = FindObjectOfType<FadeInOutScreen>();
        StartCoroutine(Setup());
    }

    public IEnumerator Setup()
    {
        fadeInOutScreen.ShowScreenNoDelay();

        if (clothSpawns.Length > 0)
        {
            if (!sceneData.isSet)
            {
                sceneData._clothes = new Clothes_Base[clothSpawns.Length];
                for (int i = 0; i < clothSpawns.Length; i++)
                {
                    clothSpawns[i].SetRandomBase();
                    sceneData._clothes[i] = clothSpawns[i].cloth.Base;
                }
                sceneData.isSet = true;
            }
            else
            {
                for (int i = 0; i < clothSpawns.Length; i++)
                {
                    clothSpawns[i].SetBase(sceneData._clothes[i]);
                }
            }
        }

        if (player.playerData.newPos == "" || player.playerData.newPos == null)
        {
            var pos = startPos[Random.Range(0, startPos.Length)];
            player.playerData.timeLeft = 60f;
            timer.UpdateTimerText(60f);
            player.transform.position = pos.transform.position;

            yield return new WaitForSeconds(0.5f);

            yield return fadeInOutScreen.FadeOut();
            isAnimating = false;
            timer.Resume();
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

            timer.duration = player.playerData.timeLeft;
            timer.UpdateTimerText(timer.duration);
            yield return new WaitForSeconds(0.5f);

            yield return fadeInOutScreen.FadeOut();
            isAnimating = false;
            player.playerData.newPos = "";
            player.canMove = true;
            timer.Resume();
        }

    }

    public IEnumerator LoadScene(string sceneName)
    {
        isAnimating = true;
        timer.Stop();
        player.playerData.timeLeft = timer.TimeRemaining;
        yield return fadeInOutScreen.FadeIn();

        yield return new WaitUntil(() => fadeInOutScreen.IsFadeOn);

        for (int i = 0; i < clothSpawns.Length; i++)
        {
            sceneData._clothes[i] = clothSpawns[i].cloth.Base;
        }

        SceneManager.LoadSceneAsync(sceneName);
    }
}
