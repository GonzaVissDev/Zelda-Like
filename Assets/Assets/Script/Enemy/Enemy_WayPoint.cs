using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WayPoint : MonoBehaviour
{
    // Creamos un Array Para guardar los Distintos puntos.
    [Tooltip("Intrduzca las distintas posiciones")]
    public GameObject[] wayPoints;
    int CurrentPosition = 0;

    //Velocidad del objeto (movimiento).
    public float speed =0.6f;

    //...
    Animator Anim;
    Rigidbody2D rb2d;


    void Start(){

        Anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update(){

      //Sistema Way Point..
                  //Primero Creamos una variable donde guarda la direccion que esta mirando el enemigo (para guardarlo en la animaciòn).
        Vector3 Direction = (wayPoints[CurrentPosition].transform.position - transform.position).normalized;
        Anim.SetFloat("MovX", Direction.x);
        Anim.SetFloat("MovY", Direction.y);
                     //Luego hacemos una variable de tipo float(Distance) que nos permitira saber la distancia que hay entre nosotros y unos de los puntos.
       float Distance = Vector3.Distance(wayPoints[CurrentPosition].transform.position, transform.position);
                     // Configuración del movimiento
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[CurrentPosition].transform.position, Time.deltaTime * speed);
        if (Distance <= 0)
        {//El if nos permitira saber si llegamos nuestro destino (de ser asi, crea otro destino de forma alatoreo)
            CurrentPosition = Random.Range(0, wayPoints.Length);
        }
        
    }


    //Comprovamos si el objeto toca al jugador y de ser asi cambiamos el destino.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Comprobación para evitar que se salga del limite de la Array de objetos.
            if (CurrentPosition != 0) --CurrentPosition;
            else
                CurrentPosition++;
        }
    }

}
