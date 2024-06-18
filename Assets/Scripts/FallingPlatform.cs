using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector3 _originalPosition;
    private float fallDelay = 1f;
    private Collider2D _collider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _originalPosition = transform.position;
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.transform.position.y >= transform.position.y) 
        {
            StartCoroutine(Fall());
        }

        if (collision.gameObject.CompareTag("ResetPlatform"))
        {
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        _collider.enabled = false;
        yield return new WaitForSeconds(3f);
        _collider.enabled = true;
    }

    private IEnumerator Reset() 
    {
        yield return new WaitForSeconds(fallDelay);
        _rigidbody.bodyType= RigidbodyType2D.Kinematic;
        transform.position = _originalPosition;
    }
}
