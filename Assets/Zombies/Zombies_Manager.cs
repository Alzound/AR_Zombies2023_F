using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Zombies_Manager : MonoBehaviour
{
   public List<GameObject> zombies_Container = new List<GameObject>();
   public List<Transform> Spawn_Ponts = new List<Transform>();
    public int TimeBetweenZombies=2;
    public int ZombiesCounter;
    public float currentTime;
    public GameObject ZombiePrefab;
   

    private void Awake()
    {
       
        for (int i = 0; i <= ZombiesCounter; i++) //este lo realiza por la cantidad de balas, -intancia objeto-lo desactiva-lo agrega a la lista
        {
            var prefabInstance = Instantiate(ZombiePrefab);
            prefabInstance.SetActive(false);
            zombies_Container.Add(prefabInstance);
        }
    }

    public GameObject getNewZombie() //esta funcion es para darle un objeto desactivado al input y que este lo active
    {
        if (ZombiesCounter > 0)
        {
            for (int i = 0; i <= ZombiesCounter; i++)
            {
                if (!zombies_Container[i].activeInHierarchy) //comienza el conteo, si no esta activo, lo manda al input pasando por todos los objetos
                {
                    return zombies_Container[i];

                }

            }
        }
        if (ZombiesCounter <= 0)
        {

          
        }
        return null;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        TouchPressed();
    }
    public void TouchPressed()
    {
        //Debug.Log("tap");
        //llama al objeto 
        if (currentTime >= TimeBetweenZombies)
        {
            var zombie = getNewZombie();
            if (zombie == null)
                return;
            int Random_index = Random.Range(0, Spawn_Ponts.Count);
            Transform newReference = Spawn_Ponts[Random_index];
            zombie.transform.position = new Vector3(newReference.position.x, newReference.position.y, newReference.position.z);
         
            zombie.SetActive(true);
            currentTime = 0;
          
        }
    }
}
