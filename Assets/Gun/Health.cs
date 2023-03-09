using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnDeath;
    public float life=100;
    [SerializeField] private Image LifeBar;
    public float currentHealth = 100;
    public float MaxHealth = 100;
    public float lessHealth = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LifeBar.fillAmount = currentHealth / MaxHealth;
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hit"))
        {
            currentHealth -= lessHealth * Time.deltaTime;
        }
    }


}
