using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private List<InventoryCapsule> inventroyCapsule;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private Image outfitCapsule, hatCapsule, hairCapsule;
    private Color fullWhite = new Color(255, 255, 255, 255);
    private Color invisibleWhite = new Color(255, 255, 255, 0);

    private void Awake()
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

    private void Start()
    {
        outfitCapsule.sprite = playerInventory.Items[0].icon;
        hairCapsule.sprite = playerInventory.Items[1].icon;
    }
    public void DisplayItemsOnInventory()
    {
        for (int i = 0; i < playerInventory.Items.Count; i++)
        {
            inventroyCapsule[i].item = playerInventory.Items[i];
            Image itemImg = inventroyCapsule[i].transform.GetChild(0).GetComponent<Image>();
            itemImg.sprite = playerInventory.Items[i].icon;
            itemImg.color = fullWhite;

            Button btn = inventroyCapsule[i].GetComponent<Button>();
            SetInvCapsuleListener(btn, i);
            btn.interactable = true;
        }
    }
    public void CleanItemsOnInventory()
    {
        for (int i = 0; i < inventroyCapsule.Count; i++)
        {
            if (inventroyCapsule[i].item != null)
            {
                inventroyCapsule[i].item = null;
                Image itemImg = inventroyCapsule[i].transform.GetChild(0).GetComponent<Image>();
                itemImg.color = invisibleWhite;

                Button btn = inventroyCapsule[i].GetComponent<Button>();
                btn.onClick.RemoveAllListeners();
                btn.interactable = false;
            }
        }
        CleanEquipedItems();
    }
    void CleanEquipedItems()
    {
        outfitCapsule.color = invisibleWhite;
        hatCapsule.color = invisibleWhite;
        hairCapsule.color = invisibleWhite;
    }

    private void SetInvCapsuleListener(Button btn, int index)
    {
        btn.onClick.AddListener(() => { inventroyCapsule[index].SelectItem(); });
    }
    public void SelectedItem(Item item)
    {
        switch (item.itemType)
        {
            case ItemType.Outfit:
                SetUpEquipment(item, outfitCapsule, () => { playerInventory.SetOutfit(item); });
                break;
            case ItemType.Hair:
                SetUpEquipment(item, hairCapsule, () => { playerInventory.SetHair(item); });
                break;
            case ItemType.Hat:
                SetUpEquipment(item, hatCapsule, () => { playerInventory.SetHat(item); });
                break;
        }
    }
    void SetUpEquipment(Item itemToSet, Image targetImg, Action func)
    {
        func.Invoke();
        targetImg.sprite = itemToSet.icon;
        targetImg.color = fullWhite;
    }
}
