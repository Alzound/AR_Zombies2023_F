using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    [Header("Player Input")]
    private InputAction touchAction;
    private PlayerInput playerInput;
     

    [Header("Effect")]
    public ParticleSystem effect;
    public AudioSource gunEffect;
    public AudioClip gun;

    [Header("Bullet")]
    public List<GameObject> bullets_Container = new List<GameObject>(); //lista para contener balas
    
    public GameObject bullet_Prefab;
   
    public Transform referencePosition; //posicion de donde ser�n disparadas las balas
    public Transform referenceRotation; 
    public int amount = 10;
    public float timeBetweenShoots = 1;
  

    private float currentTime = 0; 

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchAction = playerInput.actions["Touch"];
        for (int i = 0; i <= amount; i++) //este lo realiza por la cantidad de balas, -intancia objeto-lo desactiva-lo agrega a la lista
        {
            var prefabInstance = Instantiate(bullet_Prefab);  
            prefabInstance.SetActive(false); 
            bullets_Container.Add(prefabInstance); 
        }
    }

    private void OnEnable()
    {
        touchAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchAction.performed -= TouchPressed;
    }

    private void Update()
    {
        currentTime += Time.deltaTime; //inicia un contador
       
    }
    
    public GameObject getNewBullet() //esta funcion es para darle un objeto desactivado al input y que este lo active
    {
        for (int i = 0; i <= amount; i++)  
        {
            if (!bullets_Container[i].activeInHierarchy) //comienza el conteo, si no esta activo, lo manda al input pasando por todos los objetos
            {
                return bullets_Container[i];
            }

        }

        return null; 
    }

    /*
    public void shootBullet()
    {
        var bullet = getNewBullet(); //lama al objeto 

        if (Input.GetButtonDown("Fire1") && currentTime >= timeBetweenShoots)//solo falta ponerle el input mobile
        {
            if (bullet == null)
                return;

            bullet.transform.position = new Vector3(referencePosition.transform.position.x, referencePosition.transform.position.y, referencePosition.transform.position.z);
            var rot = referenceRotation.transform.rotation;
            bullet.transform.rotation = rot;
            bullet.SetActive(true);
            currentTime = 0;
        }
    }
    */

    public void TouchPressed(InputAction.CallbackContext context)
    {
        //Debug.Log("tap");
        var bullet = getNewBullet(); //lama al objeto 
        if (currentTime >= timeBetweenShoots)//solo falta ponerle el input mobile
        {
            if (bullet == null)
                return;
            effect.Play();
            gunEffect.PlayOneShot(gun); 
            bullet.transform.position = new Vector3(referencePosition.transform.position.x, referencePosition.transform.position.y, referencePosition.transform.position.z);
            var rot = referenceRotation.transform.rotation;
            bullet.transform.rotation = rot;
            bullet.SetActive(true);
            currentTime = 0;
        }
    }
}
