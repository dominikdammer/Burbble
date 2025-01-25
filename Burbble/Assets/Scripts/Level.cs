using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Level/Create New Level")]
public class Level : ScriptableObject
{
    [Header("Fischarten (6 Werte)")]
    public int[] intFischarten = new int[6];

    [Header("Zielt�ne (6 Werte)")]
    public int[] intZielt�ne = new int[6];

    [Header("UI-Asset")]
    public Sprite uiImage;
}

