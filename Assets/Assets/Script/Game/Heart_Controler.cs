using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_Controler : MonoBehaviour
{
    public GameObject[] heart;
    private int Hp;
  
    
    public void Hp_Management(bool hit,int Hp){

        if (Hp <= heart.Length) heart[Hp].SendMessage("Hp",hit);
    }
}