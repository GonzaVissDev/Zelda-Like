using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float Fire_Time;
    private Player player;
    private Animator Fire_Anim;


    private void Start()
    {
        Fire_Anim = GetComponent<Animator>();
        player = GetComponent<Player>();

        //Comprobacion rapida para asegurarnos de que estemos enviando la informaciòn de forma correcta.
        GameObject PlayerObject= GameObject.FindWithTag("Player");

        if (PlayerObject != null)
        {
            player = PlayerObject.GetComponent<Player>();

        }

        StartCoroutine(FireOn(Fire_Time));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Player"){
            // Falta Enviar el Dmg al la vida del jugador.
        }
    }

    //Una vez creado el fuego, Se destruirá a los segundos que se declare anteriormente.
    IEnumerator FireOn (float Time)
    {
        yield return new WaitForSeconds(Time);
        Fire_Anim.SetBool("FireOff", true);
        Destroy(this.gameObject,1f);
    }
}