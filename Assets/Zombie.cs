using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
  

    private ParticleSystem pSystem;
    private Animator animator;
    public AnimationClip DieAnim;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveToPlayer()
    {
        //Movimiento.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Muerto");
            /*animator.Play(DieAnim.name);
            pSystem.Play(); */
        }
    }
   
}
