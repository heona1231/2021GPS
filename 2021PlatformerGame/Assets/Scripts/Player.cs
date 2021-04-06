using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float jumpPower = 5.0f;

    public Transform groundChecker;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rigid;
    bool isGround = true;

    private Animator anim;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Jump();
        Move();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("isAttack", true);
            SoundManager.instance.AtttackSound();

            Collider2D col = Physics2D.OverlapCircle(transform.position, 2, (1 << LayerMask.NameToLayer("Enemy")));

            /*
            Collider2D[] cols;
            for(int i = 0; i < cols.Length; i++)
            {

            }
            */
            if (col != null)
            {
                col.GetComponent<Enemy>().Die();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("isAttack", false);
        }
        isGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);
        
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGround)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    void Move()
    {
        float posX = Input.GetAxis("Horizontal");

        if (posX != 0)
        {
            if(posX >= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        transform.Translate(Mathf.Abs(posX) * Vector3.right * moveSpeed * Time.deltaTime);
    }

}
