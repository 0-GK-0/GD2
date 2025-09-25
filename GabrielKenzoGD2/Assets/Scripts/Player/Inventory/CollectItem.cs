using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [Header("Collect")]
    public float distance;
    public Transform player;
    public LayerMask itemLayer;
    public KeyCode collectKey = KeyCode.E;

    [Header("Inventory")]
    public Inventory inventory;

    private void Update()
    {
        Collect();
    }
    void Collect()
    {
        if (Input.GetKeyDown(collectKey))
        {
            RaycastHit hit;
            bool ray = Physics.Raycast(player.position, player.forward, out hit, distance, itemLayer);

            if (ray)
            {
                if (hit.collider.CompareTag("Item"))
                {
                    Item item = hit.collider.gameObject.GetComponent<Item>();
                    item.Collect();
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
