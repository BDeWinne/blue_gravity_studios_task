using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/CreateNewItem", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;
    public ItemType itemType;
    public int clothId;
}
public enum ItemType
{
    Outfit,
    Hat,
    Hair,
    Other
}
