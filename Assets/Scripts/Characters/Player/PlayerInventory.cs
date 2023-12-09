using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int coins { get; private set; } = 1000;
    public int maxInventorySpace { get; private set; } = 20;
    public List<Item> items { get; private set; }
    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void ModifyCoinsCount(int value)
    {
        coins -= value;
    }
}
