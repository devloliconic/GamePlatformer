using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartpicker : MonoBehaviour
{
    private hero hero;
    private void Start()
    {
        hero = FindObjectOfType<hero>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "heart")
        {
            hero.lives += 1;
            Destroy(collision.gameObject);
        }
    }
}
