using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.5f;
    [Tooltip("Cantidad de vida del jugador (siemrpe es uno menos por el Array de corazon en *Heart Controler*")]
    public int HP_Player = 2;
    int HPMax_Player;
    Animator P_Animator;
    Rigidbody2D P_Rig;
    bool P_Stop = false;
    public float KnockBack;
    public Material Hit_Material;
    private Material Default_Material;
    private float Time_Material = 0.2f;
    private SpriteRenderer Sr;

    private bool Frozen = false;
    private Heart_Controler Hc;
   

    [HideInInspector]
    public  Vector2 movimiento;

    // Start is called before the first frame update
    void Start()
    {
        P_Animator = GetComponent<Animator>();
        P_Rig = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        Hc = GetComponent<Heart_Controler>();

        GameObject HeartObject = GameObject.FindGameObjectWithTag("Heart");
        if (HeartObject != null) Hc= HeartObject.GetComponent<Heart_Controler>();

        HPMax_Player = HP_Player;
        Default_Material = Sr.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Frozen == false) movimiento = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movimiento != Vector2.zero && Frozen == false)
        {
            P_Animator.SetFloat("MovX", movimiento.x);
            P_Animator.SetFloat("MovY", movimiento.y);
            P_Animator.SetBool("Walking", true);

        }
        else{
            P_Animator.SetBool("Walking", false);
        }
    }


    private void FixedUpdate()
    {
        if (P_Stop == false) P_Rig.MovePosition(P_Rig.position + movimiento * speed * Time.deltaTime);
        
    }

    public void P_Mov(bool PMov){
        
        P_Stop = PMov;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("GenericEnemy") || collision.gameObject.CompareTag("Boss"))
        {

            Sr.material = Hit_Material;
            StartCoroutine(RestoreDefaultMaterial(Time_Material));

            Debug.Log(HP_Player);

            if (HP_Player >= -1)
            {
                Hc.Hp_Management(true, HP_Player);
                --HP_Player;
            }
            if (HP_Player <= -1)
            {
                Debug.Log("LLegue hasta aca");
                Destroy(this.gameObject);
            }


            //Knock Back Effect 
            Vector3 diference = transform.position - collision.transform.position;
            diference = diference.normalized * KnockBack;
            transform.position = new Vector3(transform.position.x + diference.x, transform.position.y + diference.y);
        }
    }

    public IEnumerator FreezePlayer (float Time)
    {
        movimiento = Vector2.zero;
        Frozen = true;
     yield return new WaitForSeconds(Time);
        Frozen = false;
    }
    public void Health (int Value){
      
        if (HP_Player <HPMax_Player) {
            HP_Player += Value;
            Hc.Hp_Management(false,HP_Player);
        }
    }

    IEnumerator RestoreDefaultMaterial(float Time)
    {
        yield return new WaitForSeconds(Time);
        Sr.material = Default_Material;
    }
}