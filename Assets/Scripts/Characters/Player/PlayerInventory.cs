using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int coins { get; private set; } = 1000;
    public int maxInventorySpace { get; private set; } = 20;
    [SerializeField] private List<Item> items;
    public List<Item> Items => items;
    public TorsoController torsoController { get; private set; }
    public HairController hairController { get; private set; }
    public HatController hatController { get; private set; }

    private void Start()
    {
        torsoController = GetComponentInChildren<TorsoController>();
        hairController = GetComponentInChildren<HairController>();
        hatController = GetComponentInChildren<HatController>();
    }
    public void AddItem(Item item)
    {
        items.Add(item);
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
    public void ModifyCoinsCount(int value)
    {
        coins += value;
    }
    public void SetOutfit(Item item)
    {
        torsoController.SetClothId(item.clothId);
    }
    public void SetHair(Item item)
    {
        hairController.SetClothId(item.clothId);
    }
    public void SetHat(Item item)
    {
        hatController.SetClothId(item.clothId);
    }
}
