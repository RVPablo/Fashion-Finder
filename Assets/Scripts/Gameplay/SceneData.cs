using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneData : ScriptableObject
{
    [SerializeField] public bool isSet = false;
    [SerializeField] public Clothes_Base[] _clothes;

    public void Reset()
    {
        isSet = false;
        _clothes = new Clothes_Base[0];
    }
}
