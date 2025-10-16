using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemObj> itemList;
    public GameObject inventory;
    public bool isOpened = false;
    public KeyCode inventoryKey = KeyCode.F;

    [Header("Slots")]
    public Sprite emptySprite;
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;
    public Image slot5;

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
        if(itemList[0] == null) itemList[0] = newItem;
        else if(itemList[1] == null) itemList[1] = newItem;
        else if(itemList[2] == null) itemList[2] = newItem;
        else if(itemList[3] == null) itemList[3] = newItem;
        else if(itemList[4] == null) itemList[4] = newItem;
        Debug.Log(newItem.itemname);
        Slot();
    }

    public void Slot()
    {
        if (itemList[0] != null) slot1.sprite = itemList[0].itemSprite;
        else slot1.sprite = emptySprite;
        if (itemList[1] != null) slot2.sprite = itemList[1].itemSprite;
        else slot2.sprite = emptySprite;
        if (itemList[2] != null) slot3.sprite = itemList[2].itemSprite;
        else slot3.sprite = emptySprite;
        if (itemList[3] != null) slot4.sprite = itemList[3].itemSprite;
        else slot4.sprite = emptySprite;
        if (itemList[4] != null) slot5.sprite = itemList[4].itemSprite;
        else slot5.sprite = emptySprite;
    }
}