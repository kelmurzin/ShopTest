using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private Money money;
    
    private void Start() => money.onValueChange += UpdateMoneyText; 
    
    private void OnDestroy() => money.onValueChange -= UpdateMoneyText;
    
    private void UpdateMoneyText(int value) => moneyText.text = "Money: " + value.ToString();
    
}
