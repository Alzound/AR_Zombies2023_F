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
        
        Vector3 force = new Vector3(0, 0, b_Speed * Time.deltaTime);     
        rb.AddForce(force, ForceMode.Impulse);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"));
        {
            this.gameObject.SetActive(false);
        }
    }
}
