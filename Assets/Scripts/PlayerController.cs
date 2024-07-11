using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float InputHorizontal;

    [Header("GroundCheck")]
    public LayerMask jumpableGround;
    public Vector2 _boxSize;
    public float _castDistance;


    [Header("Dash")]
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    //attackvars
    private float lastAttackUsed;
    public float attackCooldown;
   
    //playerstats
    [SerializeField] public float MovementSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //impedir que haja qualquer movimento enquanto se da o dash
        if (isDashing)
        {
            return;
        }

        //movement and knockback
        InputHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(InputHorizontal * MovementSpeed, rb.velocity.y);
        
        
        //jump
        if(Input.GetKey(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        //dash
        if(Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        //attack
        if(Input.GetMouseButton(0) && Time.time > lastAttackUsed + attackCooldown) 
        {
            animator.SetTrigger("isAttacking");
            lastAttackUsed = Time.time;
        }

        //turning sprite around when he walks in a different direction
        if (InputHorizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        } if(InputHorizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        //walking animation
        if (InputHorizontal != 0) 
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }


    private IEnumerator Dash() 
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale; //buscar a gravidade original
        rb.gravityScale = 0; // desativar a gravidade para o dash ser mais eficiente
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity; //apos o dash voltar � gravidade original 
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    //verificar se o jogador esta no chao
    private bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, _boxSize, 0f, Vector2.down, _castDistance, jumpableGround))
        {
            return true;
        } 
        else
        {
            return false;   
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * _castDistance, _boxSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth hp = GetComponent<PlayerHealth>();
            hp.TakeDamage(5);
        }
    }
}
