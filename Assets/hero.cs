using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 8f;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public BoxCollider2D bc;
    public Sprite dog;
    public Sprite bird;
    public Sprite rat;
    public Sprite oldSprite;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {   
        //man idle
        if (isGrounded && bc.size == new Vector2((float)0.3500786, (float)0.6035978))
        {
            State = States.idle;
        }
        //dog idle
        if (isGrounded && bc.size == new Vector2((float)0.6187489, (float)0.6479998))
        {
            State = States.dog_idle;
        }
        //rat idle
        if (isGrounded && bc.size == new Vector2((float)0.5015686, (float)0.1840866))
        {
            State = States.rat_idle ;
        }
        //man run
        if (Input.GetButton("Horizontal") && bc.size == new Vector2((float)0.3500786, (float)0.6035978))
        {
            State = States.run;
            Run();
        }
        //dog run
        if (Input.GetButton("Horizontal") && bc.size == new Vector2((float)0.6187489, (float)0.6479998))
        {
            State = States.dog_run;
            Run();
        }
        if (Input.GetButton("Horizontal") && bc.size == new Vector2((float)0.5015686, (float)0.1840866))
        {
            State = States.rat_run;
            Run();
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.F1))
        {
            if(bc.size != new Vector2((float)0.6187489, (float)0.6479998))
            {
                bc.size = new Vector2((float)0.6187489, (float)0.6479998);
                bc.offset = new Vector2((float)0.1, (float)(0.6479998 / 2));
                State = States.animtodog;
                ChangeSprite(dog);
                speed = 6f;
                jumpForce = 12f;
            }
        }
        if (Input.GetKey(KeyCode.F2))
        {
            if(bc.size != new Vector2((float)0.3500786, (float)0.6035978))
            {
                bc.size = new Vector2((float)0.3500786, (float)0.6035978);
                bc.offset = new Vector2((float)-0.1309199, (float)0.8081097);
                State = States.animtodog;
                ChangeSprite(oldSprite);
                speed = 3f;
                jumpForce = 8f;
            }
        }
        if (Input.GetKey(KeyCode.F3))
        {
            if(bc.size != new Vector2((float)0.5015686, (float)0.1840866))
            {
                bc.size = new Vector2((float)0.5015686, (float)0.1840866);
                bc.offset = new Vector2((float)-0.05141503, (float)0.1840866 * (float)1.44);
                State = States.animtodog;
                ChangeSprite(rat);
                speed = 3f;
                jumpForce = 4f;
            }
        }
        if (Input.GetKey(KeyCode.F4))
        {
            bc.size = new Vector2((float)0.3849311, (float)0.3380481);
            bc.offset = new Vector2((float)-0.07007718, (float)0.3537292);
            ChangeSprite(bird);
        }
        if(timeBtwAttack <= 0)
        {
            if (Input.GetMouseButton(0) && bc.size == new Vector2((float)0.3500786, (float)0.6035978))
            {
                State = States.atack;
               //aCollider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
//                for (int i = 0; i < enemies.Length; i++)
  //              {
    //                enemies[].GetComponent<Enemy>.TakeDamage(damage);
      //          }
            }
            if (Input.GetMouseButton(0) && bc.size == new Vector2((float)0.6187489, (float)0.6479998))
            {
                State = States.dogattack;
                //aCollider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                //                for (int i = 0; i < enemies.Length; i++)
                //              {
                //                enemies[].GetComponent<Enemy>.TakeDamage(damage);
                //          }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    private void Run()
    {

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        spriteRenderer.flipX = dir.x < 0.0f;
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }
    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
public enum States
{
    idle,
    run,
    animtodog,
    dog_idle,
    dog_run,
    rat_idle,
    rat_run,
    atack,
    dogattack
}