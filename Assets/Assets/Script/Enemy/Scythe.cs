using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    public float Speed = 3f;
    public float MaxRange;
    Vector3 StartPosition;
    private float Time = 3;
    public GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;

        StartCoroutine(AttackOn());
        
    }


    IEnumerator AttackOn()
    {
        //Falta comprar Cuando llega a su punto maximo Asi vuelve;
         rb2d.velocity = transform.right * Speed;
        yield return new WaitForSeconds(Time);
         
        rb2d.velocity = Vector2.zero;
        anim.SetBool("Hit", true);
        StartCoroutine(Back());
     
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(0.35f);
        rb2d.velocity = transform.right * -1;
        InvokeRepeating("InvokeFire", 0.1f, 0.5f);
        Destroy(this.gameObject, 3f);
        
       

       
    }

    void InvokeFire()
    {
        Instantiate(Fire, transform.position, transform.rotation);
    }
    }

