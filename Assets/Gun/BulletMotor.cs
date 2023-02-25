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
    }
    // Update is called once per frame
    void Update()
    {
        float desiredSpeed = b_Speed * Time.deltaTime;
       rb.velocity = transform.forward * desiredSpeed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"));
        {
            this.gameObject.SetActive(false);
        }
    }
}
