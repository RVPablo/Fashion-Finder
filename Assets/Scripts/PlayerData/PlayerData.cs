using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public bool isGameStarted = false;
    public string newPos;
    public Clothes_Base[] clothes = new Clothes_Base[4];
    public float timeLeft;
    public float volume;

    public void Reset()
    {
        isGameStarted = true;
        newPos = string.Empty;
        clothes = new Clothes_Base[4];
    }
}
