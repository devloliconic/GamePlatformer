using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] public int lives = 5;
    [SerializeField] private float jumpForce = 8f;

    private string lname;
    private bool moveInput;
    private bool facingRight = true;


    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    public Animator anim;
    private SpriteRenderer spriteRenderer;
    public BoxCollider2D bc;
    public Sprite dog;
    public Sprite oldSprite;
    private float chek;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetButton("Horizontal");
  /*      if (facingRight == false && moveInput > 0)
        {
            Flip();
        }*/
        if (moveInput && bc.size == new Vector2((float)0.3500786, (float)0.6035978))
        {
            anim.SetBool("isRunning", true);
            //anim.SetBool("isDogRunning", false);
        }
        else if(!moveInput && bc.size == new Vector2((float)0.3500786, (float)0.6035978))
        {
            anim.SetBool("isRunning", false);
        }
        if (moveInput && bc.size == new Vector2((float)0.6187489, (float)0.6479998))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isDogRunning", true);
        }
        else if (!moveInput && bc.size == new Vector2((float)0.6187489, (float)0.6479998))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isDogRunning", false);
        }
    }
    private void Update()
    {
        lname = SceneManager.GetActiveScene().name;
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if (Input.GetButton("Horizontal"))
        {
            //State = States.run;
            Run();
        }
 
        if (Input.GetKey(KeyCode.F1))
        {
            if(bc.size != new Vector2((float)0.6187489, (float)0.6479998))
            {
                bc.size = new Vector2((float)0.6187489, (float)0.6479998);
                ChangeSprite(dog);
                anim.SetBool("isDog", true);
                speed = 6f;
                jumpForce = 12f;
            }
        }
        if (Input.GetKey(KeyCode.F2))
        {
            if(bc.size != new Vector2((float)0.3500786, (float)0.6035978))
            {
                bc.size = new Vector2((float)0.3500786, (float)0.6035978);
                anim.SetBool("isDog", false);
                ChangeSprite(oldSprite);
                speed = 3f;
                jumpForce = 8f;
            }
        }
        if(lives <= 0)
        {
            dead();
        }
    }
    private void Run()
    {

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        chek = Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        //spriteRenderer.flipX = dir.x < 0.0f;
        if(chek > 0 && facingRight == false)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        else if(chek < 0 && facingRight == true)
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }
    void jump()
    {

        rb.velocity = Vector2.up * jumpForce;

        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length >= 1;

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    void dead()
    {
        SceneManager.LoadScene(lname);
    }

}