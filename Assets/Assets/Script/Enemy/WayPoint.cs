using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public GameObject[] wayPoints;
    public float Speed;
    int CurrentPosition = 0;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(wayPoints[CurrentPosition].transform.position, transform.position);

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[CurrentPosition].transform.position, Time.deltaTime * Speed);
        if (Distance <= 0)
        {
            CurrentPosition = Random.Range(0, wayPoints.Length);
        }

    }
}

