using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeMechanic : MonoBehaviour
{
    //Tiempo inicial donde Invocamos el Objeto y Cada cuanto se va a Repetir.

    public GameObject I_Object;
    public float First_Invoke;
    public float Second_Invoke;

    // Start is called before the first frame update
    void Start()
    {  //Variable que genera un valor alatoreo entre el primer tiempo de invocacion y el segundo.
        float Rng = Random.Range(First_Invoke, Second_Invoke);
        InvokeRepeating("InvokeObject", First_Invoke, Rng);
    }

    //Meto para invocar el Objeto Fuego.
    void InvokeObject()
    {
        Instantiate(I_Object, transform.position, transform.rotation);
    }
}
