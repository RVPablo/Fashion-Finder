using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerData PlayerData;
    public ClothStyles Theme = ClothStyles.Chic;
    public float Scoreduboug;
    public int nbVet;

    public Text scoreText;

    void Update()
    {
        CalcScore();
    }

    public void CalcScore()
    {
        nbVet = 0;
        Scoreduboug = 0;

        for (int i = 0; i < PlayerData.clothes.Length; i++)
        {
            if (PlayerData.clothes[i] != null)
            {
                nbVet++;
                if (PlayerData.clothes[i].Style == Theme)
                {
                    Scoreduboug += 2;
                }
                if (PlayerData.clothes[i].Rarity != 0)
                {
                    Scoreduboug += PlayerData.clothes[i].Rarity;
                }
                else
                {
                    Scoreduboug += 1;
                }
                Debug.Log("rareté:" + PlayerData.clothes[i].Rarity);
            }
        }

        UpdateScoreText();
        //Debug.Log("Le score est de :" + Scoreduboug + "/ Le nombre de vetements est:" + nbVet);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Scoreduboug.ToString();
        }
    }
}
