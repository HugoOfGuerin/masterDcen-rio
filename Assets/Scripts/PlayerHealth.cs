using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int _currentHealth = 5;
    public int _maxHealth;
 
    private SimpleFlash _damageFlash;

    public HealthBar _healthBar;
    public void Start()
    {
        _currentHealth = _maxHealth;
        _damageFlash = GetComponent<SimpleFlash>();
        _healthBar.SetMaxHealth(_maxHealth);
    }

    //fun�ao para dar dano ao gameobject onde � aplicado
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log($"Damage: {damage}");
        _damageFlash.CallDamageFlash();
        _healthBar.SetHealth(_currentHealth);
    }

    public void HealHealth(int heal)
    {
        _currentHealth += heal;
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
