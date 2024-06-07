using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Rendering;
using TMPro;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    public Camera Camera;
    public GameObject player;
    public GameObject Girl;
    public GameObject Chair;
    public FadeInOutScreen fade;
    public PlayerData playerData;
    public Vector2[] WayPoints;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    Animator playerAnim;

    private void Start()
    {
        playerAnim = player.GetComponent<Animator>();
        Camera.transform.position = new Vector3(2f, 2.8f, -10);
        fade.ShowScreenNoDelay();
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        yield return fade.FadeOut();

        playerAnim.SetTrigger("Walk");
        var sequence = DOTween.Sequence();
        sequence.Append(player.transform.DOLocalMove(WayPoints[0], 3f));
        sequence.Join(Camera.transform.DOLocalMoveY(1.85f, 3f));

        yield return new WaitForSeconds(2.8f);
        playerAnim.SetTrigger("IdleLeft");

        yield return new WaitForSeconds(0.25f);

        var sequence2 = DOTween.Sequence();
        sequence2.Append(Chair.transform.DOLocalMoveX(5.1f, 1f));
        sequence2.Join(player.transform.DOLocalJump(new Vector3(1.47f, 1.8f, 0f), 1f, 1, 1f));
        playerAnim.SetTrigger("Sit");

        yield return new WaitForSeconds(1.5f);

        dialogBox.SetActive(true);
        if (playerData.Score == 10)
        {
            yield return TypeDialog("Your dress is so good! 10/10!", 30);
        }
        else if (playerData.Score >= 7)
        {
            yield return TypeDialog($"Your dress suits you! {playerData.Score}/10!", 30);
        }
        else if (playerData.Score >= 4)
        {
            yield return TypeDialog($"I hope you'll find better clothes next time! {playerData.Score}/10!", 30);
        }
        else if (playerData.Score >= 1)
        {
            yield return TypeDialog($"What the hell is that dress?! {playerData.Score}/10!", 30);
        }
        else
        {
            yield return TypeDialog("Police! I'm being threatening by a weirdo! 0/10!", 30);
        }

        dialogBox.SetActive(false);

        yield return LoadScene("Start");
    }

    public IEnumerator TypeDialog(string dialog, int letterPerSecond)
    {
        dialogText.text = "";
        foreach (var letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }

        yield return new WaitForSeconds(2f);
    }

    public IEnumerator LoadScene(string sceneName)
    {
        yield return fade.FadeIn();

        yield return new WaitUntil(() => fade.IsFadeOn);

        SceneManager.LoadSceneAsync(sceneName);
    }
}
