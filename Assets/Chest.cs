using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private CanvasManagement Can;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Can = GetComponent<CanvasManagement>();

        GameObject CanvasObject = GameObject.FindGameObjectWithTag("Canvas");
        if (CanvasObject != null) Can = CanvasObject.GetComponent<CanvasManagement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Anim.SetBool("Open",true);
            Can.WinGame();
        }
    }
}
