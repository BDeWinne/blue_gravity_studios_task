using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] Image iconRenderer;
    [SerializeField] TextMeshProUGUI nameTxt, priceTxt;
    Button btn;
    public void FillItemSlotData(Item item)
    {
        iconRenderer.sprite = item.icon;
        nameTxt.text = item.itemName;
        priceTxt.text = item.price.ToString();
        this.item = item;
    }
    public void SetSlotForBuy()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(BuyItem);
    }
    void BuyItem()
    {
        if (TradePanelManager.Instance.PlayerInventory.coins > item.price)
        {
            TradePanelManager.Instance.ItemBought(item);
            DestroySlot();
            UI_Manager.Instance.UpdateCoinsUI();
        }
    }

    public void SetSlotForSell()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SellItem);
    }
    void SellItem()
    {
        TradePanelManager.Instance.ItemSold(item);
        DestroySlot();
        UI_Manager.Instance.UpdateCoinsUI();
    }
    public void DestroySlot()
    {
        Destroy(gameObject);
    }
}
