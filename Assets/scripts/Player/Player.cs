using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Controls")]
    public Joystick joystick;
    public float playerSpeed;

    [Header("HP")]
    private int playerHP;
    public int maxPlayerHP;

    [Header("Spawn")]
    
    [SerializeField]
    public int id;

    public static Action<int> toHertsSygnal;
    public static Action apperOfPlayer;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator anim;
    private bool directedRight = true;
    private bool invicebleState = false;

  


    private void OnDisable()
    {
        
    }

    void Awake()
    {
        playerHP = maxPlayerHP;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        apperOfPlayer?.Invoke();
        toHertsSygnal?.Invoke(maxPlayerHP);
        joystick = GameObject.FindWithTag("Joystick").GetComponent<joystickCostil>().joystick;
    }



    
    void Update()
    {
        rb.WakeUp();
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * playerSpeed;

        if(moveInput.x == 0)
        {
            anim.SetBool("running", false);
        }
        else
        {
            anim.SetBool("running", true);
        }

        if(!directedRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (directedRight && moveInput.x < 0)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        directedRight = !directedRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void changeHP(int dmg)
    {
        if (!invicebleState) {
            playerHP -= dmg;
            if (playerHP > maxPlayerHP)
            {
                playerHP = maxPlayerHP;
                toHertsSygnal?.Invoke(playerHP);
            }
            else
            {
                toHertsSygnal?.Invoke(playerHP);
                if (playerHP <= 0)
                {
                    Die();
                }
                else if (dmg > 0 && !invicebleState)
                {
                    invicebleState = true;
                    anim.SetTrigger("take damage");
                    Invoke("SetVinceble", 0.7f);
                }
                else
                {

                }
            }
        }
    }

    public void SetVinceble()
    {
        invicebleState = false;
    }

    public void SetInvinceble()
    {
        invicebleState = true;
    }

    void Die()
    {
        anim.SetTrigger("dead");
        GetComponent<Collider2D>().enabled = false;
        Destroy(GetComponent<Combat>());
        //GetComponent<Animator>().enabled = false;
        this.enabled = false;
    }

}
