using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Level/Create New Level")]
public class Level : ScriptableObject
{
    [Header("Fischarten (6 Werte)")]
    public int[] intFischarten = new int[6];

    [Header("Zieltöne (6 Werte)")]
    public int[] intZieltöne = new int[6];
}

