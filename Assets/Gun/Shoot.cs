using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public BulletManager bulletManager;
    private void Update()
    {
        bulletManager.shootBullet(); //usando modelo vista controlador alv       
    }
    
   
}
