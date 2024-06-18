using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;

    //detetar se o que entra no collider da arma é um inimigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Health hp = collision.GetComponent<Health>();
            hp.TakeDamage(damage);
        }

        if(collision.CompareTag("Dummy"))
        {
            Animator dummyHit = collision.GetComponent<Animator>();
            dummyHit.SetTrigger("Hit");
        }
    }
}
