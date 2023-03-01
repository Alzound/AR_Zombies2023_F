using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zombie : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI zombies;
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
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
       
        transform.LookAt(player.transform.position);
        rb.position = Vector3.Lerp(rb.position, player.transform.position, speed);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            numberone = +1;
            zombies.text = numberone.ToString();
            this.gameObject.SetActive(false);
            Debug.Log("Muerto");
            anim.Play();
            pSystem.Play(); 
        }
    }
   
}
