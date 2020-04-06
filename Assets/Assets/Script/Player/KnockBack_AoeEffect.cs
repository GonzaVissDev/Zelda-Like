using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack_AoeEffect : MonoBehaviour
{
    private float KnockBackStrength;
    private float KnockBackRadius;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, KnockBackRadius);
        for(int i =0;i < colliders.Length;i++)
        {
            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();
            if (rb != null) rb.AddExplosionForce(KnockBackStrength, transform.position, KnockBackRadius, 0f, ForceMode.Force);
        }

    }
}
