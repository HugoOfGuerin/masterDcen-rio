using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlash : MonoBehaviour
{
    public Color _flashColor = Color.white;
    public float _flashTimer = 0.25f;

    private SpriteRenderer _renderer;
    private Material _material;

    private Coroutine _damageFlashCoroutine;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _material = _renderer.material;
    }
   
    public void CallDamageFlash()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlasher());
    }
    private IEnumerator DamageFlasher()
    {
        _material.SetColor("_FlashColor", _flashColor);// mudar a cor do material para a cor de dano

        float currentFlashAmount = 0f;
        float elapsedTime = 0f;

        //timer que define a duraçao do flash
        while (elapsedTime < _flashTimer)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / _flashTimer));
            _material.SetFloat("_FlashAmount", currentFlashAmount);

            yield return null;
        }
    }
}
