using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    //Variables de las estadisticas del Enemigo.
    public float Vision_Radius;
    public float Attack_Radius;
    public float AtkSpeed;
    public float speed;
    bool IsAttackig;
    public float KoPower;
    public float koTime;

    // Variable para guardar El Objetos que utilizaremos.
    public GameObject Projectile;

    GameObject Player;
    Animator Tree_Anim;
    Rigidbody2D rb2d;

    //Variable para guardar la posicion inicial
    Vector3 StartPosition,target;
 


    void Start()
    {
        //Guardamos Player gracias a su Tag.

        Player = GameObject.FindGameObjectWithTag("Player");
        // Guardo la posicion Actual.
        StartPosition = transform.position;

        Tree_Anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 Target = StartPosition;

        //Comprobamos en un RayCast la distancia del enemigo hacia el jugador.
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, Player.transform.position - transform.position,
            Vision_Radius, 1 << LayerMask.NameToLayer("Player"));

        //Debug del RayCast

        Vector3 Forward = transform.TransformDirection(Player.transform.position - transform.position);
        Debug.DrawRay(transform.position, Forward, Color.red);

        //Si el RayCast encuentra al jugador lo ponemos dentro del Target
        if (hit.collider != null)
        {if (hit.collider.tag == "Player")
            {
                Target = Player.transform.position;
                
            }
        }

        // Ahora Calculo la distancia que hay entre la direccion actual hasta el Target
        float Distance = Vector3.Distance(Target, transform.position);
        Vector3 Dir = (Target - transform.position).normalized;
 

        //Si es el enemigo y Esta en rango de Ataque, se queda quieto para Disparar
        if (Target != StartPosition && Distance < Attack_Radius)
        {
            Tree_Anim.SetFloat("TreeX", Dir.x);
            Tree_Anim.SetFloat("TreeY", Dir.y);
            Tree_Anim.Play("Walk",-1,0); // Congela la animacion.
            if (!IsAttackig) StartCoroutine(Attack(AtkSpeed));
        }
        else {
              rb2d.MovePosition(rb2d.transform.position + Dir * (speed * Time.deltaTime));
           
            // al moverse necesitamos establecer la animacion de movimiento.
            Tree_Anim.speed = 1;
            Tree_Anim.SetFloat("TreeX", Dir.x);
            Tree_Anim.SetFloat("TreeY", Dir.y);
            Tree_Anim.SetBool("Walking", true);
        }
        
        //Comprobacion para evitar Bugs.

        if (Target == StartPosition && Distance < 0.05f)
        {
            transform.position = StartPosition;
            Tree_Anim.SetBool("Walking", false);
        }

        Debug.DrawLine(transform.position, Target, Color.green);
    }

    //Metodo para dibujar los Gizmos.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Vision_Radius);
        Gizmos.DrawWireSphere(transform.position, Attack_Radius);
    }
    
        /*KnockBack
        Vector3 diference = transform.position - Hitpostion;
        diference = diference.normalized * KoPower;
        transform.position = new Vector3(transform.position.x + diference.x, transform.position.y + diference.y);
        StartCoroutine(KnockCo(rb2d));*/

 

    //Creamos un Enumarator para Comprobar si tiene que hace el KO.
    IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            enemy.velocity = Vector2.zero;
            yield return new WaitForSeconds(koTime);

            enemy.velocity = Vector2.zero;
        }
    }
    
    // Enumerator que nos sirvira para saber cada cuanto tiene que atacar el enemigo.
    IEnumerator Attack(float speed)
    {
        IsAttackig = true;

        Instantiate(Projectile, transform.position, transform.rotation);

        yield return new WaitForSecondsRealtime(speed);

        IsAttackig = false;
    }
}
