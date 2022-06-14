using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    public void Update()
    {
        if (true)
        {
            anim.SetBool("isrun", true);
        }
        //anim.SetBool("isrun", false);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
