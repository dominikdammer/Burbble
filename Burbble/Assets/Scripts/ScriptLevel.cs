using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;



[CreateAssetMenu(fileName = "NewLevel", menuName = "Level/Create New Level")]
public class Level : ScriptableObject
{
    public enum Fischart
    {
        Lachs,
        Forelle,
        Thunfisch

    }

    public enum Zielt�ne
    {
        C,
        D,
        E,
        F,
        G

    }

    [Header("Fischarten (6 Werte)")]
    public Fischart[] fischarten = new Fischart[6];

    [Header("Zielt�ne (6 Werte)")]
    public Zielt�ne[] zielt�ne = new Zielt�ne[6];
}
