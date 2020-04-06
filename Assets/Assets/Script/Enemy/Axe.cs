using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float Speed;
    public float TimeinScene =3f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveForward());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);
    }

    IEnumerator MoveForward()
    {
        rb2d.velocity = transform.right * Speed;
        yield return new WaitForSeconds(TimeinScene);
        Destroy(this.gameObject);
    }
}