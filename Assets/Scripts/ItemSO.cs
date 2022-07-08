using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemName", menuName = "Scriptable Objects/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public string Name;
    public string Discription;
    public int Cost;
    public string ProductID;
}
