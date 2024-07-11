using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform _playerTransform;
    public float walkSpeed;
    public float chaseRange;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(_playerTransform.position, transform.position) < chaseRange)
        {
            float dist = _playerTransform.position.x - transform.position.x;
            _rb.velocity = Vector2.right * dist * walkSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
