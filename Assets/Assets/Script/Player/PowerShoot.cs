using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShoot : MonoBehaviour
{
    [Tooltip("Tiempo que tarda en destruirse,despues de colisionar.")]
    public float PowerShoot_Time;
    [HideInInspector]
    public Vector2 PS_Mov;
    public float PS_Speed;

    // Update is called once per frame
    void Update()
    {
      transform.position += new Vector3(PS_Mov.x, PS_Mov.y, 0) * PS_Speed * Time.deltaTime;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Object"){
            
            collision.GetComponent<DestructibleObject>().Destroy_Object();
            yield return new WaitForSeconds(PowerShoot_Time);
            Destroy(this.gameObject);
        }
        if (collision.tag == "GenericEnemy" || collision.tag == "Boss")
        {
           
            collision.GetComponent<HpManagement>().LostHp();

            yield return new WaitForSeconds(PowerShoot_Time);
            Destroy(this.gameObject);
        }
        else if (collision.tag != "Player"){
           
            Destroy(gameObject,2.5f);
        }
      
           
    }
}
