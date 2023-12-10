using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradePanelManager : MonoBehaviour
{
    public static TradePanelManager Instance;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform playerTradeScreenTrs, traderTradeScreenTrs;
    private NPC_Controller currentNpc;
    [SerializeField] private PlayerInventory playerInventory;
    public PlayerInventory PlayerInventory => playerInventory;
    [SerializeField] private List<ItemSlot> playerItemSlots = new List<ItemSlot>();
    [SerializeField] private List<ItemSlot> traderItemSlots = new List<ItemSlot>();
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void BuildTradeScreen(NPC_Controller npc)
    {
        currentNpc = npc;
        for (int i = 0; i < playerInventory.Items.Count; i++)
        {
            CreateSlot(playerTradeScreenTrs, playerItemSlots, i, playerInventory.Items[i], setSlotForSell: true);
        }
        for (int i = 0; i < currentNpc.items.Count; i++)
        {
            CreateSlot(traderTradeScreenTrs, traderItemSlots, i, currentNpc.items[i], setSlotForBuy: true);
        }
    }
    public void ItemBought(Item item)
    {
        playerInventory.ModifyCoinsCount(-item.price);
        playerInventory.AddItem(item);
        currentNpc.RemoveItem(item);
        CreateSlot(playerTradeScreenTrs, playerItemSlots, playerInventory.Items.Count - 1, item, setSlotForSell: true);
    }
    public void ItemSold(Item item)
    {
        playerInventory.ModifyCoinsCount(item.price);
        playerInventory.RemoveItem(item);
        currentNpc.AddItem(item);
        CreateSlot(traderTradeScreenTrs, traderItemSlots, currentNpc.items.Count - 1, item, setSlotForBuy: true);
    }
    void CreateSlot(Transform parent, List<ItemSlot> listToAdd, int index, Item item, bool setSlotForBuy = false, bool setSlotForSell = false)
    {
        GameObject slot = Instantiate(itemSlotPrefab, parent);
        listToAdd.Add(slot.GetComponent<ItemSlot>());
        listToAdd[index].FillItemSlotData(item);
        if (setSlotForBuy)
        {
            listToAdd[index].SetSlotForBuy();
        }
        if (setSlotForSell)
        {
            listToAdd[index].SetSlotForSell();
        }
    }
    public void CleanTradeScreen()
    {
        for (int i = 0; i < playerItemSlots.Count; i++)
        {
            if (playerItemSlots[i] != null)
            {
                playerItemSlots[i].DestroySlot();
            }
        }
        for (int i = 0; i < traderItemSlots.Count; i++)
        {
            if (traderItemSlots[i] != null)
            {
                traderItemSlots[i].DestroySlot();
            }
        }
        playerItemSlots = new List<ItemSlot>();
        traderItemSlots = new List<ItemSlot>();
        currentNpc = null;
    }
}
