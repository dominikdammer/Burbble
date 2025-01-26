using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Level/Create New Level")]
public class Level : ScriptableObject
{
    [Header("Fischarten (6 Werte)")]
    public int[] intFischarten = new int[6];

    [Header("Zieltone (6 Werte)")]
    public int[] intZieltone = new int[6];

    [Header("UI-Asset")]
    public GameObject[] ToneIndicatorBubble = new GameObject[6];
}

