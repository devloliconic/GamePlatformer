using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class heartpicker : MonoBehaviour
{
    private hero hero;
    public TMP_Text heartText;
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
    private void Update()
    {
        heartText.text = hero.lives.ToString();
    }
}
