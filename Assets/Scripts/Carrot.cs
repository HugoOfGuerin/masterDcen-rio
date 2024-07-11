using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Carrot : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.AddCarrotsToInventory();
            Destroy(gameObject);
        }
    }
}
