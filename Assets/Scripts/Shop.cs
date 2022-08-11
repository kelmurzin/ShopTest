using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ItemSO[] itemSO;
    [SerializeField] private ItemTemplate[] itemTemplate;
    [SerializeField] private Money money;
    
    public void ActivateItem(string productId)
    {
        PlayerPrefs.SetInt(productId, 1);
        CheckActivateItem();
    }

    public void CheckActivateItem()
    {
        for (int i = 0; i < itemSO.Length; i++)
        {
            if (PlayerPrefs.GetInt(itemTemplate[i].ProductID, 0) == 0)
            {
                itemTemplate[i].ItemAvailability.interactable = false;
                itemTemplate[i].ItemAvailabilityText.text = "Заблокировано";
                itemTemplate[i].ItemAvailabilityText.color = Color.red;
            }
            else
            {
                itemTemplate[i].ItemAvailability.interactable = true;
                itemTemplate[i].ItemAvailabilityText.text = "Доступно";
                itemTemplate[i].ItemAvailabilityText.color = Color.green;
            }
        }
    }

    public void CheckMoneyForButton(int money)
    {
        for(int i = 0; i < itemSO.Length; i++)
        {
            if (money >= itemSO[i].Cost & PlayerPrefs.GetInt(itemTemplate[i].ProductID, 0) == 0)
                itemTemplate[i].ButtonItem.interactable = true;
            else
                itemTemplate[i].ButtonItem.interactable = false;
        }
    }

    private void Start()
    {
        money.onValueChange += CheckMoneyForButton;
        LoadInfoItem();
        CheckActivateItem(); 
    }

    private void OnDestroy() => money.onValueChange -= CheckMoneyForButton;

    private void LoadInfoItem()
    {
        for ( int i = 0;i < itemSO.Length; i++)
        {
            itemTemplate[i].Name.text = itemSO[i].Name;
            itemTemplate[i].Discription.text = itemSO[i].Discription;
            itemTemplate[i].Cost.text = itemSO[i].Cost.ToString();
            itemTemplate[i].index = i;
            itemTemplate[i].ProductID = itemSO[i].ProductID;

        }
    }
}
