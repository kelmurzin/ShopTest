using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemName", menuName = "Scriptable Objects/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public string Name => nameItem;
    public string Discription => discription;
    public int Cost => cost;
    public string ProductID => productID;
    
    [SerializeField] private string nameItem;
    [SerializeField] private string discription;
    [SerializeField] private int cost;
    [SerializeField] private string productID;
    
}
