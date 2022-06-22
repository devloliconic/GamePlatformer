using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadbl : MonoBehaviour
{
    private void Start()
    {
        hero = FindObjectOfType<hero>();
    }
    private hero hero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "deadb")
        {
            hero.lives = 0;
        }
    }
}
