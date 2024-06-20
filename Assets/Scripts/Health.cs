using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int _currentHealth = 5;
    public int _maxHealth;

    public void Start()
    {
        _currentHealth = _maxHealth;
    }

    //fun�ao para dar dano ao gameobject onde � aplicado
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Damage: {damage}");
    }

    //detetar se o objeto tem menos de 0 de vida, se sim destruir o objeto
    public void Update()
    {
        if (_currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
