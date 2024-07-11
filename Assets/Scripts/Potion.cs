using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Item _potionData;
    public int _quantity = 1;
    public int _healAmount = 10;

    public PlayerHealth _playerHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItemToInventory(_potionData, _quantity);
            Destroy(gameObject);
        }
    }
}
