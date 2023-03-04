using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zombie : MonoBehaviour
{
    int numberone = 0;
    private Rigidbody rb;
    private ParticleSystem pSystem;
    private Animator animator;
    private Animation anim;
    public AnimationClip DieAnim;
    public float speed;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        pSystem = GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) >= 2)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
       
      
        rb.position = Vector3.Lerp(rb.position, player.transform.position, speed);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            anim.Play(DieAnim.name);
            pSystem.Play();
            StartCoroutine(DeathSequence()); 
            Debug.Log("Muerto");
        }
    }

    public IEnumerator DeathSequence() 
    {
        
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }
   
}
