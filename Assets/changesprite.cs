using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changesprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite dog;
    public Sprite bird;
    public Sprite rat;
    public Sprite oldSprite;
    public BoxCollider2D bc;
    public Transform tr;
    private Rigidbody2D rb;
    public Vector2 S;
    public Animator anim;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
            if ( Input.GetKey(KeyCode.F1))
            {
                bc.size = new Vector2((float)0.6187489, (float)0.6479998);
                bc.offset = new Vector2((float)-0.1, (float)(0.6479998/2));
                anim.enabled = false;
                ChangeSprite(dog);
            
            }
            if (Input.GetKey(KeyCode.F2))
            {
                bc.size = new Vector2((float)0.3500786, (float)0.6035978);
                bc.offset = new Vector2((float)-0.1309199, (float)0.8081097);
                ChangeSprite(oldSprite);
                anim.enabled = true;
            }
    }
    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

}
