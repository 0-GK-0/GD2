using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObj itemObj;
    public Inventory inventory;

    public void Collect()
    {
        inventory.AddItem(itemObj);
    }
}
