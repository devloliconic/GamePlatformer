using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeroAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;
    public BoxCollider2D bc;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetMouseButton(0) && bc.size == new Vector2((float)0.3500786, (float)0.6035978))
            {
                anim.SetTrigger("manattack");

            }
            if (Input.GetMouseButton(0) && bc.size == new Vector2((float)0.6187489, (float)0.6479998))
            {
                anim.SetTrigger("dogattack");
            }
            timeBtwAttack = startTimeAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
