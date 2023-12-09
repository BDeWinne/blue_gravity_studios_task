using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePanelManager : MonoBehaviour
{
    public static TradePanelManager Instance;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform tradeScreenTrs;
    private NPC_Controller currentNpc;
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>();
    [SerializeField] private PlayerInventory playerInventory;
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
        for (int i = 0; i < npc.items.Count; i++)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, tradeScreenTrs);
            itemSlots.Add(itemSlot.GetComponent<ItemSlot>());
            itemSlots[i].CreateItemSlot(npc.items[i]);
        }
    }
    public void ItemHasBeenBought(Item item)
    {
        playerInventory.ModifyCoinsCount(item.price);
        playerInventory.AddItem(item);
        for (int i = 0; i < currentNpc.items.Count; i++)
        {
            if (item == currentNpc.items[i])
            {
                currentNpc.items.RemoveAt(i);
            }
        }
    }
    public void CleanTradeScreen()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i] != null)
            {
                itemSlots[i].DestroySlot();
            }
        }
        itemSlots = new List<ItemSlot>();
        currentNpc = null;
    }
}
