using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCapsule : MonoBehaviour
{
    public Item item;

    public void SelectItem()
    {
        InventoryManager.Instance.SelectedItem(item);
    }
}
