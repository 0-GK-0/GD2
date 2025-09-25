using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemObj> itemList;
    public GameObject inventory;
    public bool isOpened = false;
    public KeyCode inventoryKey = KeyCode.F;

    private void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            if (!isOpened)
            {
                inventory.SetActive(true);
                isOpened = true;
            }
            else
            {
                inventory.SetActive(false);
                isOpened = false;
            }
        }
    }
    public void AddItem(ItemObj newItem)
    {
        itemList.Add(newItem);
        Debug.Log(newItem.itemname);
    }
}
