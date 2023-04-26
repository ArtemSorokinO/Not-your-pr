using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 5;
    [SerializeField]
    private int bulletDamage = 1;
    [SerializeField]
    private float timeDestroy = 6;
    private Transform target;
    private Rigidbody2D rb;
    private int scale = 1;
    private Vector2 direction;
    private Animator anim;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        direction = target.position - transform.position;
        var rotation = (Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg);
        if (target.position.x < transform.position.x)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            scale = -1;
            transform.localScale = Scaler;
        }
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation);
        
        Invoke("Destroy", timeDestroy);
    }

    public void Update()
    {
        transform.Translate((new Vector2(scale,0)) * bulletSpeed * Time.deltaTime);
    }

    void Destroy()
    {
        anim.SetTrigger("die");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collisioned by bullet");
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>().changeHP(bulletDamage);
        }
        Destroy();
    }
}
