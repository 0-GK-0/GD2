using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemObj : ScriptableObject
{
    public string itemname;
    public Sprite itemSprite;
}
