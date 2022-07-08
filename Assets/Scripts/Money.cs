using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Money : MonoBehaviour
{
    [SerializeField] private MoneyUI moneyUI;
    [SerializeField] private Shop shop;
    private int AmountMoney;

    private void Start()=>    
        shop.CheckMoneyForButton(AmountMoney);
    
    public void AddMoney(int _money)
    {
        AmountMoney += _money;
        UpdateAmountMoney();
    }

    public void BuyForMoney()
    {
        GameObject ButtonItem = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        AmountMoney -= shop.itemSO[ButtonItem.GetComponentInParent<ItemTemplate>().index].Cost;
        UpdateAmountMoney();
        shop.ActivateItem(shop.itemSO[ButtonItem.GetComponentInParent<ItemTemplate>().index].ProductID);
    }

    public void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        shop.CheckActivateItem();
        shop.CheckMoneyForButton(AmountMoney);
    }

    private void UpdateAmountMoney()
    {
        moneyUI.UpdateMoneyText(AmountMoney);
        shop.CheckMoneyForButton(AmountMoney);
    }

}
