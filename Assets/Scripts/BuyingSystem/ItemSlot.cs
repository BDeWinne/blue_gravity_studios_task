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
    public void CreateItemSlot(Item item)
    {
        iconRenderer.sprite = item.icon;
        nameTxt.text = item.itemName;
        priceTxt.text = item.price.ToString();
        this.item = item;

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(BuyItem);
    }
    public void BuyItem()
    {
        TradePanelManager.Instance.ItemHasBeenBought(item);
        DestroySlot();
        UI_Manager.Instance.UpdateCoinsUI();
    }
    public void DestroySlot()
    {
        Destroy(gameObject);
    }
}
