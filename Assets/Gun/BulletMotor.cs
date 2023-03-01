using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotor : MonoBehaviour
{
    public float b_Speed = 1;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * b_Speed;
    }
    // Update is called once per frame
    void Update()
    {
       
        //transform.position += transform.forward * desiredSpeed;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"));
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * b_Speed;

    }
}
