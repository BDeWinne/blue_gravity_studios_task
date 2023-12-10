using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCapsule : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;

    public void SelectItem()
    {
        InventoryManager.Instance.SelectedItem(item);
    }
    public void OnPointerEnter(PointerEventData data)
    {
        if (item != null)
        {
            UI_Manager.Instance.SwitchOverText(item.itemName, true);
        }
    }
    public void OnPointerExit(PointerEventData data)
    {
        if (item != null)
        {
            UI_Manager.Instance.SwitchOverText("", false);
        }
    }
}
