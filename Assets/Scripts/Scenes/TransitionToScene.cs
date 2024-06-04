using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class TransitionToScene : MonoBehaviour
{
    private FadeInOutScreen fadeInOutScreen;

    public string SceneName;
    public string spawnName;




    private void Awake()
    {
        fadeInOutScreen = FindObjectOfType<FadeInOutScreen>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GridBasedMovement>())
        {
            if (collision.TryGetComponent<GridBasedMovement>(out GridBasedMovement playerMoveScript))
            {
                playerMoveScript.isWalking = false;
                playerMoveScript.gameObject.GetComponentInChildren<Animator>().SetBool("IsWalking", false);
                playerMoveScript.canMove = false;
                StartCoroutine(GoToScene(playerMoveScript));
            }
            
        }
    }

    private IEnumerator GoToScene(GridBasedMovement player)
    {
        var sceneManager = FindObjectOfType<MySceneManager>();

        yield return fadeInOutScreen.FadeIn();

        yield return new WaitUntil(() => fadeInOutScreen.IsFadeOn);

        player.playerData.newPos = spawnName;

        yield return sceneManager.LoadScene(SceneName);
    }
}
