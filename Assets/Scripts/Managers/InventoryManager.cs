using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventroyCapsule;
    [SerializeField] private PlayerInventory playerInventory;
    public void DisplayItemsOnInventory()
    {
        for (int i = 0; i < playerInventory.items.Count; i++)
        {
            Image itemImg = inventroyCapsule.transform.GetChild(0).GetComponent<Image>();
            itemImg.sprite = playerInventory.items[i].icon;
            itemImg.color = new Color(255, 255, 255, 255);
        }
    }
}
