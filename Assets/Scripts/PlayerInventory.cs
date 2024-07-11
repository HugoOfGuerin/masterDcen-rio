using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = InventoryManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseItem("Potion");
        }
    }

    public void UseItem(string itemName)
    {
        inventoryManager.UseItem(itemName);
    }
}
