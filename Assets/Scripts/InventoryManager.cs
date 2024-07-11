using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public Inventory inventory;
    public TextMeshProUGUI _carrotCounter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _carrotCounter.text = $"x{inventory.carrots}";
    }

    //funçoes para guardar informçao entre scenes
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //quando damos load a uma scene, carregar o inventario
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadInventory();
    }

    //funções para adicionar e remover itens do inventario quando os apanhamos
    public void AddItemToInventory(Item item, int quantity)
    {
        inventory.AddItem(item, quantity);
        SaveInventory();
    }

    public void RemoveItemFromInventory(Item item, int quantity)
    {
        inventory.RemoveItem(item, quantity);
        SaveInventory();
    }

    //funçao para adiconar as carrots (moeda do jogo) ao inventario
    public void AddCarrotsToInventory()
    {
        inventory.AddCarrot();
        _carrotCounter.text = $"x{inventory.carrots}";
    }

    public void UseItem(string itemName)
    {
        // Verifique se o item está no inventário
        InventorySlot slot = inventory.items.Find(i => i.item.name == itemName);
        if (slot != null && slot.quantity > 0)
        {
            // Aplique o efeito do item
            ApplyItemEffect(slot.item);

            // Remova um do inventário
            RemoveItemFromInventory(slot.item, 1);
        }
    }

    private void ApplyItemEffect(Item item)
    {
        // Aqui você pode definir o que acontece quando o item é usado
        // Por exemplo, curar o jogador, aumentar uma habilidade, etc.
        Debug.Log("Item usado: " + item.itemName);

        // Exemplo de efeito: curar o jogador
        if (item.itemName == "Potion")
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            HealthBar healthBar = FindObjectOfType<HealthBar>();    
            if (playerHealth != null)
            {
                playerHealth.HealHealth(10); // Curar 50 pontos de vida
                healthBar.SetHealth(playerHealth._currentHealth);
            }
        }
    }


    //funçoes para guardar e carregar a informação do inventario do jogador
    public void SaveInventory()
    {
        PlayerPrefs.SetInt("InventoryCount", inventory.items.Count);

        for (int i = 0; i < inventory.items.Count; i++)
        {
            PlayerPrefs.SetString("Item_" + i, inventory.items[i].item.name);
            PlayerPrefs.SetInt("Quantity_" + i, inventory.items[i].quantity);
        }

        PlayerPrefs.Save();
    }

    public void LoadInventory()
    {
        int count = PlayerPrefs.GetInt("InventoryCount", 0);
        
        for (int i = 0; i < count; i++)
        {
            string itemName = PlayerPrefs.GetString("Item_" + i);
            int quantity = PlayerPrefs.GetInt("Quantity_" + i);

            Item item = Resources.Load<Item>("Items/" + itemName);
            if (item != null)
            {
                inventory.items.Add(new InventorySlot(item, quantity));
            }
        }
    }
}
