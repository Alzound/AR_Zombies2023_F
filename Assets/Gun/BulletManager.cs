using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public List<GameObject> bullets_Container = new List<GameObject>(); //lista para contener balas
    
    public GameObject bullet_Prefab;
   
    public Transform referencePosition; //posicion de donde serán disparadas las balas
    public Transform referenceRotation; 
    public int amount = 10;
    public float timeBetweenShoots = 1;
  

    private float currentTime = 0; 

    private void Awake()
    {
        for (int i = 0; i <= amount; i++) //este lo realiza por la cantidad de balas, -intancia objeto-lo desactiva-lo agrega a la lista
        {
            var prefabInstance = Instantiate(bullet_Prefab);  
            prefabInstance.SetActive(false); 
            bullets_Container.Add(prefabInstance); 
        }
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
}
