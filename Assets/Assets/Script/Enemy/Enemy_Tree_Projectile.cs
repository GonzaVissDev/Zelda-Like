using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tree_Projectile : MonoBehaviour
{
    private Rigidbody2D rgb2d;
    public float Min_SpeedBullet;
    public float Max_SpeedBullet;
    //Acordate de Cambiar Esto por el script de Player-.
    GameObject playerscript;
    Vector3 Direction,Target;
    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        playerscript = GameObject.FindGameObjectWithTag("Player");

        if (playerscript != null)
        {
            Target = playerscript.transform.position;
            Direction = (Target - transform.position).normalized;
        }

        Destroy(this.gameObject, 3f);
    }

    void FixedUpdate()
    {
        // Si hay un objetivo movemos la roca hacia su posición
        if (Target != Vector3.zero)
        {
            float RandomSpeed = Random.Range(Min_SpeedBullet, Max_SpeedBullet);
            rgb2d.MovePosition(transform.position + (Direction * RandomSpeed) * Time.deltaTime);
       
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(this.gameObject);

        }
    }
}