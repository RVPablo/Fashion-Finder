using System.Collections.Generic;
using UnityEngine;

public class ClothSpawn : MonoBehaviour
{
    public Cloth cloth;
    public List<Clothes_Base> clothesBases;

    public void SetRandomBase()
    {
        if (clothesBases != null)
            cloth.SetBase(clothesBases[Random.Range(0, clothesBases.Count)]);
        else
            cloth.TakeBase();
    }

    public void SetBase(Clothes_Base newBase)
    {
        cloth.SetBase(newBase);
    }
}
