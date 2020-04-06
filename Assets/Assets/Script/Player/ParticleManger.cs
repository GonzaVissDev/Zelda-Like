using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManger : MonoBehaviour
{
    public float  waitBeforePlay;
    Animator Anim_Particle;
    Coroutine ParticleManager;
    bool Load;

    private void Start()
    {
        Anim_Particle = GetComponent<Animator>();
    }


    public void ParticleStart()
    {
        ParticleManager = StartCoroutine(Manager());
        Anim_Particle.Play("Aura_Idle");
    }

    public void ParticleStop(){
        StopCoroutine(ParticleManager);
        Anim_Particle.Play("Aura_Idle");
        Load = false;
    }


    //Metodo para comprobar si ya cargo el tiempo
    public IEnumerator Manager(){
        yield return new WaitForSecondsRealtime(waitBeforePlay);
        Anim_Particle.Play("Aura_Play");
        Load = true;
    }

    public bool IsLoaded()
    {
        return Load;
    }
}