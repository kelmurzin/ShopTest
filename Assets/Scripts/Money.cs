using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Money : MonoBehaviour
{
    public event Action<int> onValueChange = delegate { };
    public int AmountMoney => amountMoney;

    [SerializeField] private Shop shop;
    private int amountMoney;
    private GameObject buttonItem;

    public void AddMoney(int _money)
    {
        amountMoney += _money;
        onValueChange(amountMoney);
    }

    public void BuyForMoney()
    {
        buttonItem = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        amountMoney -= shop.itemSO[buttonItem.GetComponentInParent<ItemTemplate>().index].Cost;
        onValueChange(amountMoney);
        shop.ActivateItem(shop.itemSO[buttonItem.GetComponentInParent<ItemTemplate>().index].ProductID);
    }

    public void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        shop.CheckActivateItem();
        onValueChange(amountMoney);
    }

    private void Start() => onValueChange(amountMoney);
}
