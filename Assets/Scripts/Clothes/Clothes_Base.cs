using UnityEngine;

[CreateAssetMenu]
public class Clothes_Base : ScriptableObject
{
    [SerializeField] int rarity;
    [SerializeField] string name;
    [SerializeField] ClothStyles style;
    [SerializeField] ClothTypes type;
    [SerializeField] Sprite sprite;

    public int Rarity { get { return rarity; } }
    public string Name { get { return name; } }
    public ClothStyles Style { get { return style; } }
    public ClothTypes Type { get { return type; } }
    public Sprite Sprite { get { return sprite; } }

    public Color GetColor()
    {
        var colors = new Color[] { Color.gray, Color.green, Color.blue, Color.yellow };
        return colors[rarity];
    }
}

public class StyleChart
{
    static float[][] chart =
    {
        new float[] { 2.0f, 1.0f, 0.5f},
        new float[] { 0.5f, 2.0f, 1.0f},
        new float[] { 1.0f, 0.5f, 2.0f},
    };
}

public enum ClothStyles
{
    Formal,
    Chic,
    Unformal
}

public enum ClothTypes
{
    Head,
    Torso,
    Legs,
    Shoes
}