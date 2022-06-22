using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Rigidbody2D physic;
    public Transform player;
    public bool facingRight = true;
    public float agroDistance;
    public Animator anim;
    private hero hero;
    /*private Animator anim;*/

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRenderer;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;
    float distToPlayer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        physic = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hero = FindObjectOfType<hero>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
        /*anim = GetComponent<Animator>();
*/
    }
    public void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance:" + distToPlayer);
        if (distToPlayer < agroDistance && distToPlayer > 2)
        {
            
            StartHunting();
            anim.SetBool("isrun", true);

        }
        else if(distToPlayer > agroDistance)
        {
            anim.SetBool("isrun", false);
            StopHunting();
        }
        //anim.SetBool("isrun", false);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }
    public void TakeDamage(int damage)
    {
        //spriteRenderer.material = matBlink;
        //Invoke("ResetMaterial", .2f);
        health -= damage;
    }
    void StartHunting()
    {   
        if(player.position.x < transform.position.x )
        {
            physic.velocity = new Vector2(-speed, 0);
            
        }

        else if(player.position.x > transform.position.x )
        {
            physic.velocity = new Vector2(speed, 0);
        }
        if (player.position.x < transform.position.x && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        else if(player.position.x > transform.position.x && facingRight)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
    void StopHunting()
    {
        anim.SetBool("isrun", false);
        physic.velocity = new Vector2(0, 0);
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {
            if(timeBtwAttack <= 0)
            {
                physic.velocity = new Vector2(0, 0);
                anim.SetBool("isrun", false);
                anim.SetTrigger("enemyattack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
      hero.lives -= damage;
      timeBtwAttack = startTimeBtwAttack;

    }
    void ResetMaterial()
    {
        //spriteRenderer.material = matDefault;
    }
}
