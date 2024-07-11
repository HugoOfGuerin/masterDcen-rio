using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnviromentHazard : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D coll)
   {
        if (coll.gameObject.CompareTag("Player"))
        {
            PlayerHealth _playerHP = coll.gameObject.GetComponent<PlayerHealth>();
            _playerHP.TakeDamage(10);
        }
   }
}
