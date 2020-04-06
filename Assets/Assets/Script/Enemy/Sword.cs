using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody2D rgb2d;
    private Animator Anim;
    public float Min_SpeedBullet;
    public float Max_SpeedBullet;
    public float RotationForce;
    //Acordate de Cambiar Esto por el script de Player-.
    GameObject playerscript;
    public float T;
    Vector3 Direction, Target;

    private bool Attack = false;
    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        playerscript = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(GotoHit());
       
       
    }

    void FixedUpdate()
    {
        if (Attack == true)
        {
            transform.Rotate(0,0, RotationForce * 5f * Time.deltaTime);
            float RandomSpeed = Random.Range(Min_SpeedBullet, Max_SpeedBullet);
            rgb2d.MovePosition(transform.position + (Direction * RandomSpeed) * Time.deltaTime);
            Destroy(this.gameObject, 5f);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject,0.1f);
        }
    }
    IEnumerator GotoHit ()
    {

        yield return new WaitForSeconds(T);

        if (playerscript != null)
        {
            Target = playerscript.transform.position;
            Direction = (Target - transform.position).normalized;
        }
        Attack = true;
    }
}