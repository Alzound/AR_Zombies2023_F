using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BulletMotor : MonoBehaviour
{
    public float b_Speed = 1;
    private Rigidbody rb;

    private float _timer;
    private void Start()
    {
        _timer = 0;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * b_Speed;
        StartCoroutine(DeactivateBullet());
    }
    // Update is called once per frame
    void Update()
    {

        _timer += Time.deltaTime;
        //transform.position += transform.forward * desiredSpeed;

        if (_timer >= 2)
        {
            _timer = 0;
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
 
         rb.velocity = transform.forward* b_Speed;

    }

    private IEnumerator DeactivateBullet()
    {
        Debug.Log("tu mama");
        yield return new WaitForSeconds(2);
        this.transform.gameObject.SetActive(false);
    }
}