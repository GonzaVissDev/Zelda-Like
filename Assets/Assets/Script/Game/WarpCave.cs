using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpCave : MonoBehaviour
{
    private Animator Anim;
    private string Open;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("Cave"));

        Open = PlayerPrefs.GetString("Cave");
        Anim = GetComponent<Animator>();
        Anim.Play(Open);
    }
}