using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Controls")]
    public Joystick joystick;
    private float playerSpeed; //@

    [Header("HP")]
    public int playerHP;
    public int maxPlayerHP; //@
    public int maxPlayerArmor; //@

    [Header("Spawn")]
    
    [SerializeField]
    public int id;

    public static Action<int> toHertsSygnal;
    public static Action<int> toHertsSygnalSet;
    public static Action<int> toHertsSygnalArmor;
    public static Action apperOfPlayer;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator anim;
    private bool directedRight = true;
    private bool invicebleState = false;
    private float nextArmor = 3f;
    private int playerArmor;

  


    public void UpdateStats()
    {
        var stat = gameObject.GetComponent<StatsHolderPlayer>();

        maxPlayerHP = stat.maxPlayerHP;
        maxPlayerArmor = stat.playerArmor;
        playerSpeed = stat.playerSpeed;

        gameObject.GetComponent<Combat>().attackDamage = stat.attackDamage;
        gameObject.GetComponent<Combat>().heavyAttackDamage = stat.heavyAttackDamage;


    }

    void Awake()
    {
        UpdateStats();
        playerArmor = maxPlayerArmor;
        playerHP = maxPlayerHP;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.FindWithTag("Joystick").GetComponent<joystickCostil>().joystick;

        apperOfPlayer?.Invoke();
        toHertsSygnalSet?.Invoke(maxPlayerHP);
        toHertsSygnalArmor?.Invoke(playerArmor);
        toHertsSygnal?.Invoke(maxPlayerHP);
    }

    public void updateHearts()
    {
        toHertsSygnalSet?.Invoke(maxPlayerHP);
    }


    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Layer 3";
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
        nextArmor -= Time.fixedDeltaTime;
        if (nextArmor <= 0)
        {
            changeArmor(-1);
            nextArmor += 3;
        }
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

            if (playerArmor > 0 & dmg > 0)
            {
                if (playerArmor > dmg)
                {
                    changeArmor(dmg);
                }
                else
                {
                    dmg = dmg - playerArmor;
                    changeArmor(playerArmor);
                    playerHP -= dmg;
                }
            }
            else
            {
                playerHP -= dmg;
            }

            if (dmg > 0)
            {
                nextArmor = 5f;
            }
            
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
                
            }
        }
    }

    public void hill(int hill)
    {
        playerHP += hill;
        if (playerHP > maxPlayerHP) playerHP = maxPlayerHP;
        toHertsSygnal?.Invoke(playerHP);
    }

    public void changeArmor(int dmg)
    {
        if (playerArmor <= playerHP) playerArmor -= dmg;
        if (playerArmor <= maxPlayerArmor) toHertsSygnalArmor?.Invoke(playerArmor);
        else playerArmor = maxPlayerArmor;
        
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
        GameObject.FindWithTag("UIManager").GetComponent<Death>().death();
        GetComponent<Collider2D>().enabled = false;
        Destroy(GetComponent<Combat>());
        //GetComponent<Animator>().enabled = false;
        this.enabled = false;
    }

}
