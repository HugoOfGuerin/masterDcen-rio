using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health = 5;

    //funçao para dar dano ao gameobject onde é aplicado
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    //detetar se o objeto tem menos de 0 de vida, se sim destruir o objeto
    public void Update()
    {
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
