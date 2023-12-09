using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/CreateNewItem", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;
}
