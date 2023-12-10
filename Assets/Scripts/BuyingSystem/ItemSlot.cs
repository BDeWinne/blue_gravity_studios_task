using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Image iconRenderer;
    [SerializeField] private TextMeshProUGUI nameTxt, priceTxt;
    [SerializeField] private Button btn;

    public void FillItemSlotData(Item item)
    {
        iconRenderer.sprite = item.icon;
        nameTxt.text = item.itemName;
        priceTxt.text = item.price.ToString();
        this.item = item;
    }
    public void SetSlotForBuy()
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
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
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(SellItem);
    }

    private void SellItem()
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
