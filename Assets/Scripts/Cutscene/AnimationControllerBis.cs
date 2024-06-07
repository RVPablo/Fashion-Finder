using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationControllerBis : MonoBehaviour
{
    public GameObject player;
    public GameObject Cop1;
    public GameObject Cop2;
    public FadeInOutScreen fade;

    public PlayerData playerData;

    Animator playerAnim;

    private void Start()
    {
        fade.ShowScreenNoDelay();
        playerAnim = player.GetComponent<Animator>();
        playerAnim.SetBool("IsCensored", playerData.IsCensored);
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(player.transform.DOLocalMove(new Vector3(-66, -2, 0), 9f));
        sequence.Join(Cop1.transform.DOLocalMove(new Vector3(-64, -2.5f, 0), 10.5f));
        sequence.Join(Cop2.transform.DOLocalMove(new Vector3(-64, -0.8f, 0), 10.7f));

        yield return fade.FadeOut();

        yield return new WaitForSeconds(4);

        yield return LoadScene("Start");
    }

    public IEnumerator LoadScene(string sceneName)
    {
        yield return fade.FadeIn();

        yield return new WaitUntil(() => fade.IsFadeOn);

        SceneManager.LoadSceneAsync(sceneName);
    }
}
