using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    string name;
    private Animator anim;
    private bool Switch_On = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        name = "CaveDoor";
    }
    private void Update()
    {
        anim.SetBool("On", Switch_On);

        if ((Input.GetKeyDown(KeyCode.O)))
        {
            if (Switch_On == false)
            {
                Switch_On = true;
                PlayerPrefs.SetString("Cave", name);
            }
            else if (Switch_On == true)
            {
                name = "Default";
                PlayerPrefs.SetString("Cave", name);
               Switch_On = false;
            }
        }

    }
}
