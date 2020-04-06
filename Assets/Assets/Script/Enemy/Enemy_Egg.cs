using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Egg : MonoBehaviour
{

    public GameObject[] Weapon;
    public GameObject Particle;
    public float Time;
    private int RandomWeapon;
    // Start is called before the first frame update

    void Start()
    {
        RandomWeapon = Random.Range(0, Weapon.Length);
        Debug.Log("Random" + RandomWeapon);
        StartCoroutine(SummonWeapon(Time));
    }

    IEnumerator SummonWeapon(float time)
    {
        yield return new WaitForSeconds(Time);
        Instantiate(Particle, transform.position, transform.rotation);
        Instantiate(Weapon[RandomWeapon], transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}