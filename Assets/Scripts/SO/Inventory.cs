using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    public int carrots; //moeda do jogo
    public List<InventorySlot> items = new List<InventorySlot>(); //criar uma lista de itens para o inventario

    //funçao para adicionar carrots
    public void AddCarrot()
    {
        carrots += 1;
    }


    public void AddItem(Item item, int quantity)
    {
        InventorySlot slot = items.Find(i => i.item == item);

        if (slot != null)
        {
            slot.quantity += quantity; //adicionar 1 sempre que apanhamos um item do mesmo tipo
        }
        else
        {
            items.Add(new InventorySlot(item, quantity)); //caso nao tenhamos o item que apanhamos no inventario, criar um slot novo para ele
        }
    }

    public void RemoveItem(Item item, int quantity)
    {
        InventorySlot slot = items.Find(i => i.item == item);

        if (slot != null)
        {
            slot.quantity -= quantity;
            if (slot.quantity <= 0) //se a quantidade de certo item chegar a 0, eliminar do inventario
            {
                items.Remove(slot);
            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public Item item;
    public int quantity;

    public InventorySlot(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
