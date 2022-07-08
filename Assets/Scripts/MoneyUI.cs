using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    private int money;

    private void Start()=>    
        moneyText.text = "Money: " + money.ToString();
    
    public void UpdateMoneyText(int _money)
    {
        money = _money;
        moneyText.text = "Money: " + money.ToString();
    }
}
